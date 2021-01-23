    public void buttonAbout_Click(Office.IRibbonControl control)
    {
        if (control.Id != "buttonAbout")
            return;
        // it's not advised to use MessageBox in Office Addins
        // sometimes it gets blocked by Office
        MessageBox.Show("MyAddin v1.0");
    }
    public string buttonAbout_Screentip(Office.IRibbonControl control)
    {
        if (control.Id != "buttonAbout")
            return string.Empty;
        return "About Screentip";
    }
    public string buttonAbout_Supertip(Office.IRibbonControl control)
    {
        if (control.Id != "buttonAbout")
            return string.Empty;
        return "About Supertip";
    }
