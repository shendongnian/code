        Cursor standardCursor;
        Cursor differentCursor;
        public Form1()
        {
            standardCursor = Cursors.Arrow;
            differentCursor = Cursors.Cross;
        }
        private void listView1_MouseLeave(object sender, EventArgs e)
        {
            if (this.Cursor == differentCursor)
                this.Cursor = standardCursor;
        }
        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewItem lvi = listView1.GetItemAt(e.Location.X, e.Location.Y);
            if (lvi == null)
            {
                bool found = false;
                int i = 0;
                ListViewItem.ListViewSubItem lvsi = null;
                while(!found && i< listView1.Items.Count)
                {
                    lvsi = listView1.Items[i].GetSubItemAt(e.Location.X, e.Location.Y);
                    if (lvsi != null)
                        found = true;
                    i++;
                }
                if(found)
                    this.Cursor = differentCursor;
                else if (this.Cursor == differentCursor)
                    this.Cursor = standardCursor;
            }
            else
            {
                this.Cursor = differentCursor;
            }
        }
