     delegate void DUpdateTreeView(TreeView tree, List<TreeViewItem> items, Boolean clear);
     private void UpdataTreeView(TreeView tree, List<TreeViewItem> items, Boolean clear)
        {
            if (tree.InvokeRequired)
            {
                DUpdateTreeView d = new DUpdateTreeView(UpdataTreeView);
                // replace this by the main form object if the function doesn't in the main form class 
                this.Invoke(d, new object[] { tree, items, clear }); 
            }
            else
            {
                if (clear)
                {
                    tree.Items.Clear();
                }
                else
                {
                    // Here you can add the items to the treeView
                    /***
                    ItemCollection treeitems = tree.Items;
                    foreach (TreeViewItem item in items)
                    {
                        treeitems.Dispatcher.Invoke(new Action(() =>
                        {
                            treeitems.Add(item);
                        }));
                    }
                    tree.ItemsSource = treeitems;
                    ***/
                }
            }
        }
