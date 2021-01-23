    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace Your_Project_Name
    {
    class Connection
    {
        string ConnectionString;
        public Connection()
        {
            ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=C:/User/somefolder/Your_Database.accdb;Persist Security Info=False;";
            
        }
        public string getConnection()
        {
            return ConnectionString;
        }
    }
