    Page tempPage = new Page();
    UserControl myUserControl = new MyUserControl();
    tempPage.Controls.Add(myUserControl);
    
    StringWriter sw = new StringWriter();
    HttpContext.Current.Server.Execute(tempPage, sw, false);
    if (!String.IsNullOrEmpty(sw.ToString()))
    {
        return sw.ToString();
    }
