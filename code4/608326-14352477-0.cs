    private void RemoveSelectedRows(TreeView treeView, ListStore listStore)
    {
        TreeIter iter;
        
        TreePath[] treePath = treeView.Selection.GetSelectedRows();
        
        for (int i  = treePath.Length; i > 0; i--)
        {
            listStore.GetIter(out iter, treePath[(i - 1)]);
            
            string value = (string)listStore.GetValue(iter, 0);
            Console.WriteLine("Removing: " + value);
            
            listStore.Remove(ref iter);
        }
    }
