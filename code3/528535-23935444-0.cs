            // Dummy collection
            List<TreeNodeItem> treeNodeItems = new List<TreeNodeItem>();
            // Loop through collection
            foreach (TreeNodeItem item in treeNodeItems)
            {
                // Create a new tab with as text the current item its value, and set the tag of the tab to te current item.
                TabPage tabPage = new TabPage() { Text = item.Value, Tag = item };
                // Set click handler, this will be used for all dynamic created tabs
                tabPage.Click += TabClickHandler;
                // Add the tabpage
                this.tabControl.TabPages.Add(tabPage);
            }
