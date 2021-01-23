    public class DGV:DataGridView
    {
            bool isSorted = false;
    
            public override void Sort(DataGridViewColumn dataGridViewColumn, System.ComponentModel.ListSortDirection direction)
            {
                isSorted = true;
                base.Sort(dataGridViewColumn, direction);
            }
            protected override void OnSorted(EventArgs e)
            {
                base.OnSorted(e);
                isSorted = false;
    
            }
    
    protected override void SetSelectedCellCore(int columnIndex, int rowIndex, bool selected)
            {
                // here is where cell gets selected so just ignore it when sorting
                if (isSorted)
                {
                    return;
                }
    
                base.SetSelectedCellCore(columnIndex, rowIndex, selected);
    }
    }
