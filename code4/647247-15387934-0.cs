    DataTable dt;
    int iRecords = 0;
    do
    {
      dt = new DataTable();
      using(SqlConnection con = new SqlConnection(""))
      {
        SqlCommand cmd = new SqlCommand(string.Format("SELECT TOP 100 * FROM complain where ID > {0}", iRecords));
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        sda.Fill(dt);
        //Report your progress here
      }
    } while(dt.Rows.Count != 0) 
