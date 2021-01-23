    private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView source = sender as ListView;
            ListViewItem item =  source.HitTest(e.Location).Item;
            if (item != null)
            {
                MessageBox.Show("Item " + item.Text + " was double clicked on " + source.Name );
            }
        }
