    public static void ChangeEditModeToOnPropertyChanged(this DataGridView gv)
            {
                gv.CurrentCellDirtyStateChanged += (sender, args) =>
                {
                    gv.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    if (gv.CurrentCell == null)
                        return;
                    if (gv.CurrentCell.EditType != typeof(DataGridViewTextBoxEditingControl))
                        return;
                    gv.BeginEdit(false);
                    var textBox = (TextBox)gv.EditingControl;
                    textBox.SelectionStart = textBox.Text.Length;
                };
            }
