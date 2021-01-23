     public static string LoadMailTemplate(string templatePath)      
     {
                    var page = new Page();
                    Control myControl = page.LoadControl(templatePath);   
                    var sb = new StringBuilder();    
                    page.Controls.Add(myControl);
        
                    using (var sw = new StringWriter(sb))
                    {
                        page.Server.Execute(page, sw, false);
                    }
        
                    return sb.ToString();
     }
