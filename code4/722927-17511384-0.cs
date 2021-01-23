    OleDbConnection _oleCon;
            public Form1()
            {
                InitializeComponent();
                _oleCon = new OleDbConnection();
            }
    
            bool OpenConnection()
            {
                try
                {
                    string DbPath = @"D:\Ek.mdb";
                    _oleCon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False;Data Source=" + DbPath + ";";//ConfigurationSettings.AppSettings["dbConnectionString"];
                    _oleCon.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
    
            bool CloseConnection()
            {
                try
                {
                    _oleCon.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
