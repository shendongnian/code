        private void init()
        {
            listView1.Items.Add(new ListViewItem() { Content = "Hi" });
            listView1.Items.Add(new ListViewItem() { Content = "Hello"});
            listView1.Items.Add(new ListViewItem() { Content = "Buy" });
        }
        private bool find(string str)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Content.Equals(str))
                {
                    return true;
                }
            }
            return false;
        }
        private void select(string str)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Content.Equals(str))
                {
                    item.IsSelected = true;
                }
                else
                {
                    item.IsSelected = false;
                }
            }
        }
        private void onSelectedClickHandler(object sender, RoutedEventArgs e)
        {
            if (find(searchTextBox.Text))
            {
                select(searchTextBox.Text);
            }
            else
            {
                MessageBox.Show("Not found");
            }
        }
