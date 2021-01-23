       private void PopulateGridView(string tblName)
            {
                String strConnection = "Data Source=HP\\SQLEXPRESS;database=MK;Integrated Security=true";
                SqlConnection con = new SqlConnection(strConnection);
    
                try
                {
                    con.Open();
    
                    SqlCommand sqlCmd = new SqlCommand();
    
                    sqlCmd.Connection = con;
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = "select * from " + tblName;
    
                    SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
    
                    DataTable dtRecord = new DataTable();
                    sqlDataAdap.Fill(dtRecord);
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = dtRecord;
                    dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
