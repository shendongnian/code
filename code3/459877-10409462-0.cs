    void gridControl1_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e) {
        if(e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Delete) {
            // ... your code is here
            e.Handled = true;  // disable the default processing
        }
        if(e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Custom) {
            // ... your code is here
            e.Handled = true;  // disable the default processing
        }
    }
