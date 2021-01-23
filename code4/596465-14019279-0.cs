        delegate void AddListViewItemDelegate(ListViewItem abg);
        void AddListViewItem(ListViewItem abg)
        {
            if (this.InvokeRequired)
            {
                AddListViewItemDelegate del = new AddListViewItemDelegate(AddListViewItem);
                this.Invoke(del, new object() { abg });
            }
            else
            {
                listView1.Items.Add(abg);
            }
        }
