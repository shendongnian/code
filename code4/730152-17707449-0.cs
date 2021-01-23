       string cmdText = "SELECT * FROM RetentionTable WHERE [DateTime] BETWEEN ? AND ?";
       string ConnectionPath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=RetentionDB.mdb";
       try
       {
            using(OleDbConnection cn = new OleDbConnection(ConnectionPath))
            using(OleDbCommand OleDbSearch = new OleDbCommand(cmdText, cn))
            using(OleDbDataAdapter objDataAdapter = new OleDbDataAdapter(OleDbSearch))
            {
                OleDbSearch.Parameters.AddWithValue("@p1", getDateTimeFrom(""));
                OleDbSearch.Parameters.AddWithValue("@p2", getDateTimeTo(""));
                DataSet objDataSet = new DataSet();
                cn.Open();
                objDataAdapter.Fill(objDataSet);
                dataOutput.DataSource = objDataSet;
            }
        }
        catch (Exception ex)
        {
             MessageBox.Show(ex.Message.ToString());
             MessageBox.Show(ex.StackTrace.ToString());
        }
