    class MyClass
    {
        string db_Server = "10.0.0.0";
        string db_User = "myUser";
        string db_Pass = "myPassword";
        string db_Name = "myDatabase";
    
    
        public MySqlConnection GetConnection()
        {
            MySqlConnection myConnection = new MySqlConnection(string.Format(
                       "server = {0}; database = {1}; uid = {2}; pwd = {3}",
                        db_Server, db_Name, db_User, db_Pass));
            return myConnection;
        }
    }
