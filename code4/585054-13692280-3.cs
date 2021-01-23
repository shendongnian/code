        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           MyItemForm itemform = new MyItemForm(ComboBox1.Text, getCosts(ComboBox1.SelectedIndex), getTime(ComboBox1.SelectedIndex), getPicturePath(ComboBox1.SelectedIndex));
           itemform.Show();
        }
