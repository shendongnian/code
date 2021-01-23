    public class MyDgv : DataGridView
    {
        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            DataGridViewCell c = this[e.ColumnIndex, e.RowIndex];
            if (!c.ReadOnly && c is DataGridViewTextBoxCell)
            {
                this.CurrentCell = c;
                this.BeginEdit(true);
            }
        }
    }
