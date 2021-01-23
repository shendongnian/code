     public partial class Form1 : Form
        {
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
                        TaskAwaiter<string> awaiter = ProcessUrlAsync(url);
                        // or the next line, in case we use method *
                        // TaskAwaiter<string> awaiter = ProcessUrlAsync(url).GetAwaiter();                     
                        string result = awaiter.GetResult();
    
                        MessageBox.Show(result);
                    }
                });
            }        
    
            // Awaiter inside
            private TaskAwaiter<string> ProcessUrlAsync(string url)
            {
                TaskCompletionSource<string> taskCompletionSource = new TaskCompletionSource<string>();
                var handler = new WebBrowserDocumentCompletedEventHandler((s, e) =>
                {
                    // TODO: put custom processing of document right here
                    taskCompletionSource.SetResult(e.Url + ": " + webBrowser1.Document.Title);
                });
                webBrowser1.DocumentCompleted += handler;
                taskCompletionSource.Task.ContinueWith(s => { webBrowser1.DocumentCompleted -= handler; });
    
                webBrowser1.Navigate(url);
                return taskCompletionSource.Task.GetAwaiter();
            }
             
            // (*) Task<string> instead of Awaiter
            //private Task<string> ProcessUrlAsync(string url)
            //{
            //    TaskCompletionSource<string> taskCompletionSource = new TaskCompletionSource<string>();
            //    var handler = new WebBrowserDocumentCompletedEventHandler((s, e) =>
            //    {
            //        taskCompletionSource.SetResult(e.Url + ": " + webBrowser1.Document.Title);
            //    });
            //    webBrowser1.DocumentCompleted += handler;
            //    taskCompletionSource.Task.ContinueWith(s => { webBrowser1.DocumentCompleted -= handler; });
    
            //    webBrowser1.Navigate(url);
            //    return taskCompletionSource.Task;
            //}
