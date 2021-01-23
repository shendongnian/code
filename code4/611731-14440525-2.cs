     public static string LoadMailTemplate(string parameterName, object parameter, string templateControlPath)
                {
                    var page = new Page();
                    Control myControl = page.LoadControl(templatePath);
                    var sb = new StringBuilder();
                    Type type = myControl.GetType();
                    PropertyInfo[] properties = type.GetProperties();
        
                    //pass parameter here
                    foreach (var property in properties.Where(property => property.Name.Equals(parameterName)))
                    {
                        property.SetValue(myControl, parameter, null);
                    }
        
                    page.Controls.Add(myControl);
        
                    using (var sw = new StringWriter(sb))
                    {
                        page.Server.Execute(page, sw, false);
                    }
        
                    return sb.ToString();
                }
    
    
        
