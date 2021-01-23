    class BrowserInterface : Form
    {
        /* ... */
        private delegate string StringDelegate();
        public string GetTitle()
        {
            /*
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => GetTitle()));
            }
            return browser.DocumentTitle;
            */
            if (InvokeRequired)
            {
                object result = Invoke(new StringDelegate(GetTitle));
                return (string)result;
            }
            else
                return browser.DocumentTitle;
        }
        /* ... */
    }
