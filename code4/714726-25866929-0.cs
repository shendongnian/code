        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                
               MessageBox.Show(listView1.SelectedItems[0].Text);
            }
        }
