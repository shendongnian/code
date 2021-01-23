    static void Main(string[] args)
    {
        // create connection
        string ConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\mike\\Documents\\Database1.mdb;";
        OleDbConnection MyConn = new OleDbConnection(ConnStr);
        MyConn.Open();
        initTimer(MyConn);
        MyConn.Close();
        Thread.Sleep(3000); // Or: Console.ReadLine();
    }
 
