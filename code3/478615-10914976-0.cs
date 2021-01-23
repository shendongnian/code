    public void CSharpFunction(dynamic length)
    {
        for (int i = 0; i < length; i++)
        {
            dynamic obj = webBrowser1.Document.InvokeScript("getObj", new object[] { i });
            string val = obj.MyClassValue;
        }
    }
