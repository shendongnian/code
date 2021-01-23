        private void listView_Click(object sender, System.EventArgs e)
        {
            foreach (ListViewItem item in listView.Items)
            {
                item.Checked = false;
            }
        }
