    public async void AMethod()
    {
        TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
        webBrowser1.ObjectForScripting = new CallbackObject(tcs);
        webBrowser1.DocumentText = "<script> alert('script'); window.external.Completed();</script>";
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
