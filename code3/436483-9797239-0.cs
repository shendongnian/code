        void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Index != e.Index)
                {
                    item.Checked = false;
                }
            }
        }
