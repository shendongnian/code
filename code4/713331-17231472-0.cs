    List<ListViewItem> remove = new List<ListViewItem>();
            foreach (ListViewItem item in listView1.Groups[4].Items)
            {
                remove.Add(item);
            }
            foreach (ListViewItem item in remove)
            {
                remove.Remove(item);
            }
        }
