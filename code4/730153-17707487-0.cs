    private void Query()
    {
       const string ConnectionPath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=RetentionDB.mdb";
       
       try
       {
          using (var cn = new OleDbConnection(ConnectionPath))
          using (var cmd = new OleDbCommand("SELECT * FROM RetentionTable WHERE [DateTime] BETWEEN ? And ?"))
          {
             // Parameter names don't matter; OleDb uses positional parameters.
             cmd.Parameters.AddWithValue("@p0", getDateTimeFrom(""));
             cmd.Parameters.AddWithValue("@p1", getDateTimeTo(""));
             
             var objDataSet = new DataSet();
             var objDataAdapter = new OleDbDataAdapter(cmd);
             objDataAdapter.Fill(objDataSet);
             
             dataOutput.DataSource = objDataSet;
          }
       }
       catch (Exception ex)
       {
          MessageBox.Show(ex.Message.ToString());
          MessageBox.Show(ex.StackTrace.ToString());
       }
    }
