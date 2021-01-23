    static void RenderControlTo(string pathToControl, TextWriter writer)
    {
       var page = new Page();
       var control = page.LoadControl(pathToControl);
       page.Controls.Add(control);
       
       HttpContext.Current.Server.Execute(page, writer, false);
    }
    
