    static void Main(string[] args)
    {
        // create connection
        string ConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\mike\\Documents\\Database1.mdb;";
        using(OleDbConnection MyConn = new OleDbConnection(ConnStr))
        {
            MyConn.Open();
            do
            {
                Thread.Sleep(2500); // 2.5 seconds to prevent closure of the application when timer is a little bit late.
                Check(MyConn);  
            }
            while(someValueToIndicateTheApplicationCanTerminate);
        }
    }
