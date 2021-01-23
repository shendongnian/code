    public partial class Form1 : Form
    {
        WebServer _ws;
        WebBrowser _webBrowser1;
        public Form1()
        {
            InitializeComponent();
            _webBrowser1 = new WebBrowser();
            _webBrowser1.Visible = false;
            var location = Assembly.GetExecutingAssembly().Location;
            _webBrowser1.Navigate(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\test1.html");
            _webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        async void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (_ws == null)
            {
                var html = _webBrowser1.Document.GetElementsByTagName("html");
                var response = html[0].OuterHtml;
                _ws = new WebServer(response, "http://localhost:9999/");
                _ws.Run();
                _webBrowser1.Navigate("http://localhost:9999/");
            }
            else
            {
                string latitude = "";
                string longitude = "";
                await Task.Factory.StartNew(() =>
                {
                    while (string.IsNullOrEmpty(latitude))
                    {
                        System.Threading.Thread.Sleep(1000);
                        if (this.InvokeRequired)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                var latitudeEl = _webBrowser1.Document.GetElementById("latitude");
                                var longitudeEl = _webBrowser1.Document.GetElementById("longitude");
                                latitude = latitudeEl.GetAttribute("value");
                                longitude = longitudeEl.GetAttribute("value");
                            });
                        }
                    }
                });
                MessageBox.Show(String.Format("Latitude: {0} Longitude: {1}", latitude, longitude));
            }
        }
        // credits for this class go to David
        // http://www.codehosting.net/blog/BlogEngine/post/Simple-C-Web-Server.aspx
        public class WebServer
        {
            private readonly HttpListener _listener = new HttpListener();
            static string _staticContent;
            public WebServer(string[] prefixes, string content)
            {
                _staticContent = content;
                foreach (string s in prefixes)
                    _listener.Prefixes.Add(s);
                _listener.Start();
            }
            public WebServer(string content, params string[] prefixes)
                : this(prefixes,  content) { }
            public void Run()
            {
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    try
                    {
                        while (_listener.IsListening)
                        {
                            ThreadPool.QueueUserWorkItem((c) =>
                            {
                                var ctx = c as HttpListenerContext;
                                try
                                {
                                    byte[] buf = Encoding.UTF8.GetBytes(_staticContent);
                                    ctx.Response.ContentLength64 = buf.Length;
                                    ctx.Response.OutputStream.Write(buf, 0, buf.Length);
                                }
                                catch { } // suppress any exceptions
                                finally
                                {
                                    // always close the stream
                                    ctx.Response.OutputStream.Close();
                                }
                            }, _listener.GetContext());
                        }
                    }
                    catch { } // suppress any exceptions
                });
            }
            public void Stop()
            {
                _listener.Stop();
                _listener.Close();
            }
        }
    }
