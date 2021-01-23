    public static void CloseConnection(SQLConnection conn)
    {
        if (conn.State == ConnectionState.Open)
        {
           conn.Close();
           conn.Dispose();
        }
    }
  [1]: http://www.oodesign.com/singleton-pattern.html
