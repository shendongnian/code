    private void TreeView_Loaded(object sender, RoutedEventArgs e)
            {
                TreeView areaTreeView = sender as TreeView;
    
                // Expand the treeview
                if (areaTreeView != null)
                {
                    ExpandCollapseTreeNodes(areaTreeView, true);
                }
            }
 
    public static void ExpandCollapseTreeNodes(ItemsControl parentContainer, bool isExpanded)
            {
                foreach (Object item in parentContainer.Items)
                {
                    TreeViewItem currentContainer = parentContainer.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
                    if (currentContainer != null) // && currentContainer.Items.Count > 0
                    {
                        //expand the item
                        currentContainer.IsExpanded = isExpanded;                    
    
                        //if the item's children are not generated, they must be expanded
                        if (isExpanded && currentContainer.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
                        {
                            //store the event handler in a variable so we can remove it (in the handler itself)
                            EventHandler eh = null;
                            eh = new EventHandler(delegate
                            {
                                //once the children have been generated, expand those children's children then remove the event handler
                                if (currentContainer.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
                                {
                                    ExpandCollapseTreeNodes(currentContainer, isExpanded);
                                    currentContainer.ItemContainerGenerator.StatusChanged -= eh;
                                }
                            });
    
                            currentContainer.ItemContainerGenerator.StatusChanged += eh;
                        }
                        //otherwise the children have already been generated, so we can now expand those children
                        else
                        {
                            ExpandCollapseTreeNodes(currentContainer, isExpanded);
                        }
                    }
                }
            }
