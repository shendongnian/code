            private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.Enabled)
            {
                listView1.Enabled = false;
                Form2 confirm = new Form2();
                confirm.FormClosed += new FormClosedEventHandler(confirm_FormClosed);
                confirm.Show();
            }
        }
        void confirm_FormClosed(object sender, FormClosedEventArgs e)
        {
            listView1.Enabled = true;
        }
