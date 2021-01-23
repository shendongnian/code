    public class CustomDataGridView : DataGridView
    {        
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                int i = (CurrentCell.RowIndex + 1) % Rows.Count;
                CurrentCell = Rows[i].Cells[CurrentCell.ColumnIndex];
                return true;//Suppress the default behaviour which switches to the next cell. 
            }
            return base.ProcessDataGridViewKey(e);
        }
    }
