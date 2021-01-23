    class RowSelectDataGridView : DataGridView
    {
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if ((keyData & Keys.Alt) == Keys.Alt && this.SelectedRows.Count == 1)
            {
                int selIndex = this.SelectedRows[0].Index;
                int newSelIndex = selIndex + 1;
                if ((keyData & Keys.N) == Keys.N)
                {
                    if (newSelIndex >= Rows.Count) newSelIndex = 0;
                }
                else if ((keyData & Keys.P) == Keys.P)
                {
                    newSelIndex = selIndex - 1;
                    if (newSelIndex < 0) newSelIndex = Rows.Count - 1;
                }
                else return base.ProcessDialogKey(keyData);
                this.SetSelectedRowCore(selIndex, false);
                this.SetSelectedRowCore(newSelIndex, true);
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
