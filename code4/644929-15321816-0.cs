    public OleDbConnection GetOpenConnection()
    {
        string conString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|db_gym.mdb; Jet OLEDB:Database Password=gym_admin";
        OleDbConnection conn = new OleDbConnection(conString))
        conn.Open();
        return conn;
     }
                
    protected void btn_general_Click(object sender, EventArgs e)
    {
        try
        {
            using(OleDbConnection  openConnection = common.GetOpenConnection())
            {
               // I want to close this connection
               openConnection.Close(); // close asap
            }  // dispose
         }
         catch (Exception e1)
         {
         }
    }
