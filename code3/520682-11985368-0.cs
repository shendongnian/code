    private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                if (!e.Item.Selected)
                {
                    e.Item.Selected = false;
                }
                MessageBox.Show("test");
            }
        }
