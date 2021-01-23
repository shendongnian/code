        get
        {
            //// Read connection string from the text file
           // StreamReader sr = new StreamReader(System.Windows.Forms.Application.StartupPath @"C:\ConnectionString.txt");
           // connStr = sr.ReadLine();
            string connectionStringKey = null;
            connectionStringKey = ConfigurationManager.AppSettings.Get("DefaultConnectionString");
            return ConfigurationManager.ConnectionStrings[connectionStringKey];
          
        }
    }
