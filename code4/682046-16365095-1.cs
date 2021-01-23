      private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection connect = new OleDbConnection())
                {
                    connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\folder1\data\Oren.accdb;Persist Security Info=False;";
                    connect.Open();
    
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = connect;
                    cmd.CommandText = "Select * from Agreement";
    
                    StringBuilder sb = new StringBuilder();
                    IDataReader reader = cmd.ExecuteReader();
    
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0].ToString());
                        sb.Append(string.Format("{0}, {1}", reader[0].ToString(), reader[1].ToString()) + System.Environment.NewLine);
                    }
                    reader.Close();
    
                    ReportMessage(sb.ToString());
    
                }
            }
            catch (System.Data.OleDb.OleDbException lolex)
            {
                ReportException(lolex);
            }
            catch (Exception ex)
            {
                ReportException(ex);
            }
    
        }
    
    
    
    
      private void ReportException(Exception ex)
        {
            txtStatus.Text = ex.Message;
        }
    
    
        private void ReportException(System.Data.OleDb.OleDbException oleex)
        {
    
            StringBuilder sb = new StringBuilder();
            sb.Append(oleex.ErrorCode + System.Environment.NewLine);
            sb.Append(oleex.Message + System.Environment.NewLine );
            txtStatus.Text = sb.ToString();
        }
    
        private void ReportMessage(string msg)
        {
            txtStatus.Text = msg;
        }
