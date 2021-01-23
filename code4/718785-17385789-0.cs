            if (listView1.Items.Count >= 5)
            {
                if (listView1.SelectedItems[4].ToString() != "ETDF")
                {
                    editToolStripMenuItem.Enabled = false;
                }
                else if (listView1.SelectedItems[4].ToString() == "ETDF")
                {
                    editToolStripMenuItem.Enabled = true;
                }
            }
