                        dataGridView1.ColumnCount = 2; // Create 2 text box columns
                        dataGridView1.Columns[0].HeaderText = "Name";
                        dataGridView1.Columns[0].Width = 350;
                        dataGridView1.Columns[1].HeaderText = "Value";
                        dataGridView1.Columns[1].Width = 150;
     
                        DataGridViewRow heterow0 = new DataGridViewRow();
                        DataGridViewTextBoxCell textBoxCell = new DataGridViewTextBoxCell();
                        textBoxCell.Value = "Turn Over Based On";
                        DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                        comboCell.Items.Add("Chip Transaction");
                        comboCell.Items.Add("Win/Loss");
     
                        heterow0.Cells.Add(textBoxCell);
                        heterow0.Cells.Add(comboCell);
                        dataGridView1.Rows.Add(heterow0); // this row has a combo in first cell
