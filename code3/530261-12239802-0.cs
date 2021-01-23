    public string GetTitle()
    {
        if (this.browser.InvokeRequired)
        {
            this.browser.Invoke(new MethodInvoker(() => GetTitle()));
        }
        else
        {
            return browser.DocumentTitle;
        }
    }
