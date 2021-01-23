       var path = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
    
                if  (path !=null && path.Contains("AppPath"))
                {
    
                    var filepath = System.IO.Path.Combine(
                        System.Reflection.Assembly.GetExecutingAssembly().Location,
                        path.Replace("AppPath", string.Empty).ToString());
    
                    Console.WriteLine(filepath);
                }
