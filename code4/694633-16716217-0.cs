    var tasks = new Task<string>[]
    {
        new MyDownloader().Download("http://www.stackoverflow.com"),
        new MyDownloader().Download("http://www.google.com")
    };
    Task.WaitAll(tasks);
    Console.WriteLine(tasks[0].Result);
    Console.WriteLine(tasks[1].Result);
---
    public class MyDownloader
    {
        WebBrowser _wb;
        TaskCompletionSource<string> _tcs;
        ApplicationContext _ctx;
        public Task<string> Download(string url)
        {
            _tcs = new TaskCompletionSource<string>();
            var t = new Thread(()=>
            {
                _wb = new WebBrowser();
                _wb.ScriptErrorsSuppressed = true;
                _wb.DocumentCompleted += _wb_DocumentCompleted;
                _wb.Navigate(url);
                _ctx = new ApplicationContext();
                Application.Run(_ctx);
            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            return _tcs.Task;
        }
        void _wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //_tcs.TrySetResult(_wb.DocumentText);
            _tcs.TrySetResult(_wb.DocumentTitle);
            _ctx.ExitThread();
        }
    }
