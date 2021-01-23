            private bool raisedFromCode;
        private void button2_Click(object sender, EventArgs e)
        {
            raisedFromCode = true;
            listView1.Items[1].Checked = !listView1.Items[1].Checked;
            raisedFromCode = false;
        }
        private void listView1_ItemCheck(object sender, ItemCheckEventArgs args)
        {
            if (!raisedFromCode)
                MessageBox.Show("User checked");
        }
