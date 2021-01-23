    webBrowser2.ObjectForScripting = new ScriptClass();
    webBrowser2.DocumentText = "<html><script>window.external.Test('hello')</script></html>";
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class ScriptClass
    {
        public void Test(string msg)
        {
            MessageBox.Show(msg);
        }
    }
