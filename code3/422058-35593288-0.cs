    //Jump To Next & Prior Row
            if (this.CurrentRow != null)
            {
                if ((keyData & Keys.Alt) == Keys.Alt)
                {
                    int selIndex = this.CurrentRow.Index;
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
                    this.CurrentCell = this[0, newSelIndex];
                    this.SetSelectedRowCore(newSelIndex, false);
                    return true;
                }
            }
            //
