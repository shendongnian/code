    if(cbTable.SelectedItem == null)
    {
             MessageBox.Show("Please select a value in the combo box.");
             return;
    }
    
    if (labelGrid.Text == "Member" && cbTable.SelectedItem.ToString().Equals("Workout"))
            {
                string name;
                string ss;
                foreach (DataGridViewRow item in this.dtGrid1.SelectedRows)
                {
                    ss = dtGrid1.CurrentCell.Value.ToString();
                    name = dtGrid1.SelectedCells[1].Value.ToString();
                    BookMemberWorkout bmw = new BookMemberWorkout(ss, name);
                    bmw.Label2.Text = ss;
                    bmw.Label1.Text = name;
                    bmw.ShowDialog();
                }
            }
