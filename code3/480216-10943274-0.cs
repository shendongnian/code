     Configuration webConfig = WebConfigurationManager.OpenWebConfiguration("~");
     ConnectionStringsSection section = webConfig.GetSection("connectionStrings") as            
                                                  ConnectionStringsSection;
     if (section != null)
     {
       section.ConnectionStrings["NameTheCnStr"].ConnectionString = "New Connection string here";
       webConfig.Save();
      }
