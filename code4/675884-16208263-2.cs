    public static class SOExtensions
    {
        public static Task NavigateAsync(this WebBrowser wb, string url)
        {
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
            WebBrowserDocumentCompletedEventHandler completedEvent = null;
            completedEvent = (sender, e) =>
            {
                wb.DocumentCompleted -= completedEvent;
                tcs.SetResult(null);
            };
            wb.DocumentCompleted += completedEvent;
            wb.ScriptErrorsSuppressed = true;
            wb.Navigate(url);
            return tcs.Task;
        }
    }
    
    async void ProcessButtonClick()
    {
        await webBrowser1.NavigateAsync("http://www.stackoverflow.com");
        MessageBox.Show(webBrowser1.DocumentTitle);
        await webBrowser1.NavigateAsync("http://www.google.com");
        MessageBox.Show(webBrowser1.DocumentTitle);
    }
