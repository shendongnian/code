    private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item =  lvItems.HitTest(e.Location).Item;
            if (item != null)
            {
                MessageBox.Show("Item " + item.Text + " was double clicked");
            }
        }
