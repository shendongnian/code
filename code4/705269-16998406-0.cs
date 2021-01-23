    public class DBConnection
    {
        private string pass = string.Empty;
        private string dbName = string.Empty;
    
        private OleDbConnection connection;
    
        public void DBConnection(string dbName, string pass)
        {
            this.dbName = dbName;
            this.pass = pass;
    
            this.Initialize();
        }
    
        public OleDbConnection Connection
        {
            get {return this.connection;}
        }
    
        private void Initialize()
        {
            //all the initialization
            var connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + DBPath + ";" +
            "Persist Security Info = False;Jet OLEDB:Database Password=" + pass + "";
            this.connection = new OleDbConnection(connString);
        }
    }
