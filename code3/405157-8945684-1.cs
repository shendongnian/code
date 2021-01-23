    public void InsertRow()
    {
      try
      {
        using (OleDbConnection con = new OleDbConnection())
        {
          con.ConnectionString =  Users.GetConnectionString(); // your ms-access connection string
          con.Open();
          OleDbCommand cmd = new OleDbCommand();
          cmd.Connection = con;
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = "INSERT INTO Recordings(RecName,Desc,DateAdded, FileLocation) VALUES(id,textBox269.Text,richTextBox11.Text,DateTime.Now,path)";
          cmd.ExecuteNonQuery();
        }
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }
