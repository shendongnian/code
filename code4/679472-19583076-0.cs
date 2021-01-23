                    OpenFileDialog openfile1 = new OpenFileDialog();
                    if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.textBox1.Text = openfile1.FileName;
                    }
                    {
                        string pathconn = "Provider = Microsoft.jet.OLEDB.4.0; Data source=" + textBox1.Text + ";Extended Properties=\"Excel 8.0;HDR= yes;\";";
                        OleDbConnection conn = new OleDbConnection(pathconn);
                        OleDbDataAdapter MyDataAdapter = new OleDbDataAdapter("Select * from [" + textBox2.Text + "$]", conn);
                        DataTable dt = new DataTable();
                        MyDataAdapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                catch { 
}
}
