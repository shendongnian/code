     public DataTable selectgridvalues()
        {
          SqlConnection con;
          con = new SqlConnection();
          con.ConnectionString = "server='SERVER';uid='sa';pwd='1234';database='DBName'";
          con.Open();
          SqlDataAdapter adp = new SqlDataAdapter("select * from Tablename order by id ", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
        }
         private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialogExcel = new SaveFileDialog();
            saveFileDialogExcel.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (saveFileDialogExcel.ShowDialog() == DialogResult.OK)
            {
                string exportFilePath = saveFileDialogExcel.FileName;
                gridControl1.ExportToXlsx(exportFilePath);
            }
        }
