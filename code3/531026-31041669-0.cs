        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                // Create an instance of the open file dialog box.
                OpenFileDialog fld = new OpenFileDialog();
                // Set filter options and filter index.
                fld.Filter = "CSV Files (.CSV) |*.csv*";
                fld.FilterIndex = 1;
                fld.Multiselect = false;
                // Call the ShowDialog method to show the dialog box.
                if (fld.ShowDialog() == DialogResult.OK)
                {
                    txtBrowse.Text = fld.FileName;
                }
                fld = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "CSV Browse", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }
        private void btnReadCSV_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetDataTableFromCsv(txtBrowse.Text, chkHasHeader.Checked);
                grvData.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "CSV Read", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }
        static DataTable GetDataTableFromCsv(string path, bool isFirstRowHeader)
        {
            string header = isFirstRowHeader ? "Yes" : "No";
            string pathOnly = Path.GetDirectoryName(path);
            string fileName = Path.GetFileName(path);
            string sql = @"SELECT * FROM [" + fileName + "]";
            using (OleDbConnection connection = new OleDbConnection(
                      @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly +
                      ";Extended Properties=\"Text;HDR=" + header + "\""))
            using (OleDbCommand command = new OleDbCommand(sql, connection))
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                dataTable.Locale = CultureInfo.CurrentCulture;
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
              
            DataTable dt = grvData.DataSource as System.Data.DataTable; //Getting data from Datagrid
            string strSQL = "create Table " + txtTabelName.Text + " (";
            foreach (DataColumn dc in dt.Columns)
            {
                if (dc.DataType.ToString() == "System.String")
                {
                    strSQL += dc.ColumnName + " varchar(255), ";
                }
                else if (dc.DataType.ToString() == "System.Double")
                {
                    strSQL += dc.ColumnName + " Numeric(10,3), ";
                }
                else if (dc.DataType.ToString() == "System.Int32")
                {
                    strSQL += dc.ColumnName + " int, ";
                }
            }
            strSQL += ")";
             string strStatus = Executesql(strSQL);
                if (strStatus == "Table Created")
                {
                    int iCntRecords = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        strSQL = "insert into " + txtTabelName.Text + " values ("; //Inserting value to Table
                        foreach (DataColumn dc2 in dt.Columns)
                        {
                            if (dc2.DataType.ToString() == "System.String")
                            {
                                strSQL += "'" + dr[dc2.Ordinal].ToString().Replace("'", "") + "',";
                            }
                            else
                            {
                                strSQL += dr[dc2.Ordinal] + ",";
                            }
                        }
                        strSQL = strSQL.Substring(0, strSQL.Length - 1) + ")";
                        Executesql(strSQL);
                        iCntRecords += 1; //add n counter on each successfull enter
                    }
                    MessageBox.Show("Completed! " + Environment.NewLine + Environment.NewLine + iCntRecords.ToString() + " records added!", "Done!");
                }
                else
                {
                    MessageBox.Show(strStatus);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private string Executesql(string strSQL)
        {
            try
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionstring); //Connection to SQL Database
                con.Open();
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                
            }
            return "Table Created";
        }
    }
}
