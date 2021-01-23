              if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "//Profiles"))
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "//Profiles");
    
                }
         Application.Run(new form1());
