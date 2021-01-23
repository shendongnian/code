        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewComboBoxEditingControl control = e.Control as DataGridViewComboBoxEditingControl;
            if (control != null)
            {
                control.DropDownClosed -= ComboBoxDropDownClosedEvent;
                control.DropDownClosed += ComboBoxDropDownClosedEvent;
            }
            base.OnEditingControlShowing(e);
        }
        void ComboBoxDropDownClosedEvent(object sender, EventArgs e)
        {
            DataGridViewComboBoxCell cell = CurrentCell as DataGridViewComboBoxCell;
            if ((cell != null) && cell.IsInEditMode)
            {
                CommitEdit(DataGridViewDataErrorContexts.Commit);
                EndEdit();
            }
        }
