            string myTag = "aaa";
            List<ListViewItem> lst = listView1.Items.Cast<ListViewItem>().Where(i => i.Tag == myTag).ToList();
            if (lst.Count != 0)
            {
                listView1.Items.Remove(lst.First());
            }
