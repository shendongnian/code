        DependencyObject k = VisualTreeHelper.HitTest(tv_treeView, DagEventArgs.GetPosition(lv_treeView)).VisualHit;
            
        while (k != null)
            {
                if (k is TreeViewItem)
                {
                    TreeViewItem treeNode = k as TreeViewItem;
                    
                    // Check if the context is your desired type
                    if (treeNode.DataContext is YourType)
                    {
                        // save the item
                        targetTreeViewItem = treeNode;
                        
                        return;
                    }
                }
                else if (k == tv_treeview)
                {
                    Console.WriteLine("Found treeview instance");
                    return;
                }
                
                // Get the parent item if no item from YourType was found
                k = VisualTreeHelper.GetParent(k);
            }
