            class customcolumn : System.Windows.Forms.DataGridViewLinkColumn
            {
                public Dictionary<int, string> urls = new Dictionary<int, string>();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                int row_index = 0;
                int column_index = 0;
    
                customcolumn c = new customcolumn();
                dataGridView1.Columns.Add(c);
                dataGridView1.Rows.Add();
    
                //Add Link-name here:
                dataGridView1.Rows[row_index].Cells[column_index].Value = "search";
                //Add Link here:
                ((customcolumn)(dataGridView1.Columns[column_index])).urls.Add(row_index, "http://www.google.com");
            }
    
            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                foreach (KeyValuePair<int, string> url in ((customcolumn)(dataGridView1.Columns[e.ColumnIndex])).urls)
                {
                    if (url.Key == e.RowIndex)
                    {
                        Process.Start(url.Value);
                        break;
                    }
                }
            }
