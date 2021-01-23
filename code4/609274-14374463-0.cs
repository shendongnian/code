        // SelectedIndexChange Event
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get Selected Tab
            var selectedTab = tabControl1.SelectedTab;
            foreach (Control ctrl in selectedTab.Controls)
            {
                if (ctrl is TextBox)
                {
                    (ctrl as TextBox).Text = string.Empty;
                }
                if (ctrl is Label)
                {
                    (ctrl as Label).Text = string.Empty;
                }
                // Other Controls....
            }
        }
