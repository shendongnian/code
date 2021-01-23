        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox txt_sender = (TextBox)sender;
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems[0].SubItems[1].Text = txt_sender.Text;
            }
        }
