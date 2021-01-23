    private void MyErrorGrid_SelectionChanged(object sender, EventArgs e)
        {
            string getPartSelected;
            
            getPartSelected = MyErrorGrid.CurrentCell.Value.ToString();
            
            foreach(DataGridViewRow allrow in ParetoGrid.Rows)
            {
                ParetoGrid.Rows[allrow.Index].DefaultCellStyle.BackColor = Color.Empty;
                ParetoGrid.Rows[allrow.Index].Selected = false;
            }
            //might need a do while
            foreach (DataGridViewRow row in ParetoGrid.Rows)
            {
                var cellValue = row.Cells["Keycode"].Value;
                
                if (cellValue != null && cellValue.ToString() == getPartSelected)
                {
                    ParetoGrid.Rows[row.Index].DefaultCellStyle.BackColor = Color.Red;
                    ParetoGrid.Rows[row.Index].Selected = true;
                   
                   
                }
            }
        }
