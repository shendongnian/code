    static private volatile DateTime _lastTimer;
    static void Main(string[] args)
    {
        // create connection
        string ConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\mike\\Documents\\Database1.mdb;";
        OleDbConnection MyConn = new OleDbConnection(ConnStr);
        MyConn.Open();
        initTimer(MyConn);
        do
        {
             Thread.Sleep(2500); // 2.5 seconds to prevent closure of the application when timer is a little bit late.
        }
        while(_lastTimer < DateTime.Now.AddSeconds(-2));
        MyConn.Close();
    }
    static void timer_Elapsed(object sender, ElapsedEventArgs e, OleDbConnection MyConn)
    {
        Check(MyConn); // Check is a method I have in my program which takes as argument "MyConn"
        _lastTimer = DateTime.Now;
    }
