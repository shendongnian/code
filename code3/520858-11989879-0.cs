    using System.Windows.Forms;
    namespace WindowsFormsApplication5
    {
        class MyDGV : DataGridView
        {
            public bool SelectNextCell()
            {
                int row = CurrentCell.RowIndex;
                int column = CurrentCell.ColumnIndex;
                DataGridViewCell startingCell = CurrentCell;
                do
                {
                    column++;
                    if (column == Columns.Count)
                    {
                        column = 0;
                        row++;
                    }
                    if (row == Rows.Count)
                        row = 0;
                } while (this[column, row].ReadOnly == true && this[column, row] != startingCell);
                if (this[column, row] == startingCell)
                    return false;
                CurrentCell = this[column, row];
                return true;
            }
            protected override bool ProcessDataGridViewKey(KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Tab)
                    return SelectNextCell();
                return base.ProcessDataGridViewKey(e);
            }
            protected override bool ProcessDialogKey(Keys keyData)
            {
                if ((keyData & Keys.KeyCode) == Keys.Tab)
                    return SelectNextCell();
                return base.ProcessDialogKey(keyData);
            } 
        }
    }
