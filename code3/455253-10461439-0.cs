     private static Node FindTreeViewItem(IEnumerable<Node> treeViewItems, string key)
     {
          if (treeViewItems == null) return null;
          foreach (var item in treeViewItems)
          {
             if (item.AssociatedObject.ID.Equals(key))
             {
                return item;
             }
             if (item.Children != null)
             {
                var childItem = FindTreeViewItem(item.Children, key);
                if (childItem != null)
                {
                   return childItem;
                }
             }
          }
          return null;
     }
    
     private static void ExpandTreeViewItemParents(Node treeViewItem)
     {
         if (treeViewItem == null) return;
         if (treeViewItem.Parent != null)
         {
             treeViewItem.Parent.IsExpanded = true;
         }
         ExpandTreeViewItemParents(treeViewItem.Parent);
     }
