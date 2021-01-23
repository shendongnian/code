    public async void AMethod()
    {
        string script =
         @"<script>
            function Script_A() { 
                Script_B(); 
                window.external.Completed(); //call C#: CallbackObject's Completed method
            }
            function Script_B(){
                alert('in script');
            }
        </script>";
        
        TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
        webBrowser1.ObjectForScripting = new CallbackObject(tcs);
        //Ensure document text is loaded before invoking "InvokeScript",
        //by extension method "SetDocumentTextAsync" (below)
        await webBrowser1.SetDocumentTextAsync(script);
        webBrowser1.Document.InvokeScript("Script_A");
        await tcs.Task;
        MessageBox.Show("Script executed");
    }
    [ComVisible(true)]
    public class CallbackObject
    {
        TaskCompletionSource<bool> _tcs = null;
        public CallbackObject(TaskCompletionSource<bool> tcs)
        {
            _tcs = tcs;
        }
        public void Completed()
        {
            _tcs.TrySetResult(true);
        }
    }
    public static class BrowserExtensions
    {
        public static Task SetDocumentTextAsync(this WebBrowser wb, string html)
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
            wb.DocumentText = html;
            return tcs.Task;
        }
    }
