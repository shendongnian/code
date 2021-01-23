        private void ShowSelectFromListWidget()
        {
            var uc = new SelectFromListUserControl();
            uc.ItemHasBeenSelected += uc_ItemHasBeenSelected;
            MakeUserControlPrimaryWindow(uc);
        }
        void uc_ItemHasBeenSelected(object sender, 
                             SelectFromListUserControl.SelectedItemEventArgs e)
        {
            var value = e.SelectedChoice;
            ClosePrimaryUserControl();
        }
        private void MakeUserControlPrimaryWindow(UserControl uc)
        {
            // my example just puts in in a panel, but for you
            // put your special code here to handle your user control management 
            panel1.Controls.Add(uc);
        }
        private void ClosePrimaryUserControl()
        {
            // put your special code here to handle your user control management 
            panel1.Controls.Clear();
        }
