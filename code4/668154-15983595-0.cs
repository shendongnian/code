     OpenFileDialog openfiledialog1 = new OpenFileDialog();
            openfiledialog1.Title = "path select ";
            openfiledialog1.Filter = "Access 2003 (*.mdb)|*.mdb|Access 2007|*.accdb";
            if (openfiledialog1.ShowDialog() == DialogResult.OK)
            {
                txtpath.Text = openfiledialog1.InitialDirectory + openfiledialog1.FileName;
                using (OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + openfiledialog1.FileName))
                {
                   
                    con.Open();
                    DataTable schema = con.GetSchema("Columns");
                    foreach (DataRow row in schema.Rows)
                    {         
                       listBox1.Items.Add(row.Field<string>("COLUMN_NAME"));
                       cmbloadtable.Items.Add(row.Field<string>("TABLE_NAME"));
                    }
                    
                }
            }
