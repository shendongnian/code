    private void RefreshViews()
    {
    	XmlEditor.Clear();
    	XmlEditor.Text = IndentXml();
    
    	UnselectSelectedItem();
    
    	XmlTree.Items.Refresh();
    	XmlTree.UpdateLayout();
    }
    
    private void UnselectSelectedItem()
    {
    	if (XmlTree.SelectedItem != null)
    	{
    		var container = FindTreeViewSelectedItemContainer(XmlTree, XmlTree.SelectedItem);
    		if (container != null)
    		{
    			container.IsSelected = false;
    		}
    	}
    }
    
    private static TreeViewItem FindTreeViewSelectedItemContainer(ItemsControl root, object selection)
    {
    	var item = root.ItemContainerGenerator.ContainerFromItem(selection) as TreeViewItem;
    	if (item == null)
    	{
    		foreach (var subItem in root.Items)
    		{
    			item = FindTreeViewSelectedItemContainer((TreeViewItem)root.ItemContainerGenerator.ContainerFromItem(subItem), selection);
    			if (item != null)
    			{
    				break;
    			}
    		}
    	}
    
    	return item;
    }
