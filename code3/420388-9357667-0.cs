    WebBrowser browser;
    ...
    browser.ObjectForScripting = new ScriptingObject();
    ...
    browser.DocumentText="<a onclick=\"window.external.WantCookie('Cookie')\">Give some cookie</a>";
    ....
    [System.Runtime.InteropServices.ComVisible(true)]
    public class ScriptingObject
    {
        public void WantCookie(String message)
        {
            if(message=="Cookie")
                MessageBox.Show("Thanks");
            else MessageBox.Show("I want Cookie!");
        }
    }
