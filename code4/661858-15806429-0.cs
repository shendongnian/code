        private void ShowItem(string menuItemName) {
            var field = this.GetType().GetField(
                menuItemName, 
                BindingFlags.Instance |
                BindingFlags.NonPublic |
                BindingFlags.GetField);
            var mnu = field.GetValue(this) as ToolStripMenuItem;
            if (null != mnu) {
                mnu.Visible = true;
            }
        }
