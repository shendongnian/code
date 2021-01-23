    private void RebindGridView(string tablename)
    {
      String strConnection = "Data Source=HP\\SQLEXPRESS;database=MK;Integrated Security=true";
    
                SqlConnection con = new SqlConnection(strConnection);
                try
                {
    
                    con.Open();
    
                    SqlCommand sqlCmd = new SqlCommand();
    
                    sqlCmd.Connection = con;
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = "Select * from" + tablename;
    
                    SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
    
                    DataTable dtRecord = new DataTable();
                    sqlDataAdap.Fill(dtRecord);
                    gridview1.DataSource = dtRecords;
                     gridview1.DataBind();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
    }
