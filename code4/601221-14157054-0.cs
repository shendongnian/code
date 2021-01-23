    private void gridControl_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                //getting the selected object
                myObject selectedItem = dbGridView.GetRow(dbGridView.FocusedRowHandle) as myObejct;
                if (selectedItem == null) return;
                
                //now do something with that object
                .......
                e.Handled = true;
            }
        }
