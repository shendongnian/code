    private void mydatagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
            {
                foreach (var item in e.AddedCells)
                {
                    var col = item.Column as DataGridColumn;
                    var fc = col.GetCellContent(item.Item);
    
                    if (fc is TextBlock)
                    {
                        if (((fc as TextBlock).Text == (""))||((fc as TextBlock).Text == null))
                        {
                            mydatagrid.SelectedCells.Remove(item);
                            fc.Focusable = false; // not sure if neccesarry/working after the previous line
                        }
                    }
                }
            }
