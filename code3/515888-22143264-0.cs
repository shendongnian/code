            OpenFileDialog openfiledialog1 = new OpenFileDialog();
            if (openfiledialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                this.textBox_path.Text = openfiledialog1.FileName;
            }
        }
        private void LoadExcel_Click(object sender, EventArgs e)
        {
            //string pathConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+textBox_path.Text+";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
            string pathConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox_path.Text + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1'";
            OleDbConnection conn = new OleDbConnection(pathConn);
            
            conn.Open();
            OleDbDataAdapter mydataadapter = new OleDbDataAdapter("Select * from ["+textBox_sheet.Text+"$]", conn);
            DataTable dt = new DataTable();
            mydataadapter.Fill(dt);
            dataGridView1.DataSource = dt;
            
            conn.Close();
         }
