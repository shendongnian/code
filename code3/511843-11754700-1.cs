        private TreeViewItem AddNode(TreeViewItem parent, string header)
        {
            foreach (TreeViewItem subitem in parent.Items)
                if (subitem.Header.ToString() == header)
                    return subitem;
            TreeViewItem tvi = new TreeViewItem();
            tvi.Header = header;
            parent.Items.Add(tvi);
            return tvi;
        }
