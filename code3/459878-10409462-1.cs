    class MyGridControl : DevExpress.XtraGrid.GridControl {
        public MyGridControl() {
            EmbeddedNavigator.ButtonClick += EmbeddedNavigator_ButtonClick;
        }
        //...
        void EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e) {
            if(e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Delete) {
                // ... your code is here
                e.Handled = true;  // disable the default processing
            }
            if(e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Custom) {
                // ... your code is here
                e.Handled = true;  // disable the default processing
            }
        }
    }
