        RepositoryItemButtonEdit editButton;
        RepositoryItemButtonEdit deleteButton;
        private void InitRepositoryItems()
        {
            editButton = new RepositoryItemButtonEdit();
            deleteButton = new RepositoryItemButtonEdit();
            editButton.ButtonClick += editButton_ButtonClick;
            deleteButton.ButtonClick += deleteButton_ButtonClick;
            gridControl.RepositoryItems.Add(editButton);
            gridControl.RepositoryItems.Add(deleteButton);
        }
        void deleteButton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            // do some delete on button click
        }
        void editButton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           //do some edit on button click
        } 
        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.Name == "colOperations")
                e.RepositoryItem = editButton;
        }
