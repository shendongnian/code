        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           MyItemForm itemform = new MyItemForm(listView1.Text, getCosts(listView1.SelectedIndex), getTime(listView1.SelectedIndex), getPicturePath(listView1.SelectedIndex));
           itemform.Show();
        }
