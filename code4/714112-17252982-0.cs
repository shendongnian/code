    List<string> newlist = new List<string>() { "12", "34", "56", "78", "90" };
    
                dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
                dataGridView1.ColumnCount = newlist.Count;
    
                foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    c.HeaderText = "yourvalue";
                    c.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                    c.DefaultCellStyle = new DataGridViewCellStyle() { BackColor = Color.AntiqueWhite, Alignment = DataGridViewContentAlignment.MiddleCenter };
                    
                }
                
                DataGridViewRow dgr = new DataGridViewRow();
                DataGridViewRow dgr1 = new DataGridViewRow();
                //DataGridViewColumnCollection dgcc = new DataGridViewColumnCollection(dataGridView1);
                foreach (string s in newlist)
                {
                    DataGridViewTextBoxCell tc = new DataGridViewTextBoxCell();
                    DataGridViewComboBoxCell cc = new DataGridViewComboBoxCell();
                    cc.Sorted = true;
                    cc.Items.Add(s);
                    tc.Value = s;
                    dgr.Cells.Add(cc as DataGridViewCell);
                    dgr1.Cells.Add(tc);
                }
    
                dataGridView1.Rows.AddRange(new DataGridViewRow[] { dgr, dgr1 });
