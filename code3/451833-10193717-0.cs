    using(SqlConnection conn = new SqlConnection(connString))
    {
      try{
        //some code
      }
      catch(SqlException e)
        MessageBox.Show(e.Message);
    }
