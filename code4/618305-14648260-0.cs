    grid.CurrentCellDirtyStateChanged += (s, e) => 
                {
                    if (grid.IsCurrentCellDirty)
                    {
                        grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        
                        MessageBox.Show("hello");
                    }
                };
