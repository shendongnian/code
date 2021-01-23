    private void gridInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
            try
            {
                if (e.ColumnIndex > 0 && e.RowIndex > 0)
                {
                    var cell = this.gridInventory[e.ColumnIndex, e.RowIndex];
                    var clickedValue = (cell.Value != null) ? cell.Value.ToString() : string.Empty;
                    if (!string.IsNullOrEmpty(clickedValue))
                    {
    					CurrentList = CurrentList.Where(r => typeof(r_type_here).GetProperty(this.gridInventory.Columns[e.ColumnIndex].Name).GetValue(r, null) != null &&
    						typeof(r_type_here).GetProperty(this.gridInventory.Columns[e.ColumnIndex].Name).GetValue(r, null).ToString().ToUpper() == clickedValue.ToUpper()).ToList();
    
                        if (this.CurrentList != null)
                        {
                            gridInventory.DataSource = this.CurrentList;
                            this.lblRecords.Text = string.Format(@"Total Records: {0}", CurrentList.Count(c => c.ComputerID > 0));
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
