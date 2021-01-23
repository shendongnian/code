    AppDomain.CurrentDomain.UnhandledException += (s,e) => 
                   {
                      Exception ex = (Exception)e.ExceptionObject;
                      Debug.WriteLine(ex.Message);                                          
                   };
