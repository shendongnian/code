                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    DataGridViewCell cell = row.Cells[Superfrom.Index];
                   if (cell.Value.ToString() != String.Empty)
                   {
                       cell.Style.BackColor = Color.Red;
                   }
                   else
                   {
                       cell.Style.BackColor = Color.White;
                   }
                }
