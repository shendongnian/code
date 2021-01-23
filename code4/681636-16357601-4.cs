    static void Main(string[] args)
    {
        // create connection
        string ConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\mike\\Documents\\Database1.mdb;";
        using(OleDbConnection MyConn = new OleDbConnection(ConnStr))
        {
            MyConn.Open();
            do
            {
                Thread.Sleep(2000); 
                Check(MyConn);  
            }
            while(someValueToIndicateTheApplicationCanTerminate);
        }
    }
