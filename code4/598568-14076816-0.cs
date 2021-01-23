     private void saveListViewItems(string path, ListView lv)
        {
            var delimeteredListviewData = new List<string>();
            foreach (ListViewItem lvi in lv.Items)
            {
                string delimeteredItems = string.Empty;
                foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                {
                    delimeteredItems += lvsi.Text + "#";
                }
                delimeteredListviewData.Add(delimeteredItems);
            }
            System.IO.File.WriteAllLines(path, delimeteredListviewData.ToArray());
        }
        private void loadListViewItems(string path, ListView lv)
        {
            foreach (string line in System.IO.File.ReadAllLines(path))
            {
                lv.Items.Add(new ListViewItem(line.Split(new char[]{'#'}, StringSplitOptions.RemoveEmptyEntries)));
            }
        }
