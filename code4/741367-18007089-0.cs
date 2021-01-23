        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            var box = tabControl1.SelectedTab.Controls.OfType<TextBox>().Reverse().FirstOrDefault();
            if (box != null) {
                // etc...
            }
        }
 
