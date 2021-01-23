                var result = FindVisualChildren<TreeViewItem>(treeView);
    
                foreach (var item in result)
                {
                    if (item.IsSelected)
                    {
                        ....
                    }
                }
