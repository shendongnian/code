            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select file";
            fdlg.InitialDirectory = @"d:\";
            var txtFileName = fdlg.FileName;
            fdlg.Filter = "Excel Sheet(*.xlsx)|*.xlsx|Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txtFileName = fdlg.FileName;
                Import(txtFileName);
                System.Windows.Forms.Application.DoEvents();
            }
        }
        private void Import(string txtFileName)
        {
            if (txtFileName != string.Empty)
            {
                try
                {
                    String name = "Sheet1";    // default Sheet1 
                    String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                               txtFileName +
                                ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
                    OleDbConnection con = new OleDbConnection(constr);
                    OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                    con.Open();
                    OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                    System.Data.DataTable data = new System.Data.DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
