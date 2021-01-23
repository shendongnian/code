    public partial class Form1 : Form
        {
            public struct WebBrowserAwaiter
            {
                private readonly WebBrowser _webBrowser;
                private readonly string _url;
    
                private readonly TaskAwaiter<string> _innerAwaiter;
    
                public bool IsCompleted
                {
                    get
                    {
                        return _innerAwaiter.IsCompleted;
                    }
                }
    
                public WebBrowserAwaiter(WebBrowser webBrowser, string url)
                {
                    _url = url;
                    _webBrowser = webBrowser;
                    _innerAwaiter = ProcessUrlAwaitable(_webBrowser, url);
                }
    
                public string GetResult()
                {
                    return _innerAwaiter.GetResult();
    
                }
    
                public void OnCompleted(Action continuation)
                {
                    _innerAwaiter.OnCompleted(continuation);
                }
    
                private TaskAwaiter<string> ProcessUrlAwaitable(WebBrowser webBrowser, string url)
                {
                    TaskCompletionSource<string> taskCompletionSource = new TaskCompletionSource<string>();
                    var handler = new WebBrowserDocumentCompletedEventHandler((s, e) =>
                    {
                        // TODO: put custom processing of document here
                        taskCompletionSource.SetResult(e.Url + ": " + webBrowser.Document.Title);
                    });
                    webBrowser.DocumentCompleted += handler;
                    taskCompletionSource.Task.ContinueWith(s => { webBrowser.DocumentCompleted -= handler; });
    
                    webBrowser.Navigate(url);
                    return taskCompletionSource.Task.GetAwaiter();
                }
            }
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                ProcessUrlsAsync(new[] { "http://google.com", "http://microsoft.com", "http://yahoo.com" })
                    .Start();
            }
    
            private Task ProcessUrlsAsync(string[] urls)
            {
                return new Task(() =>
                {
                    foreach (string url in urls)
                    {
                        var awaiter = new WebBrowserAwaiter(webBrowser1, url);
                        string result = awaiter.GetResult();
    
                        MessageBox.Show(result);
                    }
                });
            }
        }   
            }
