    private void RemoveSelectedRows(TreeView treeView, ListStore listStore, TreeModelSort treeModelSort)
    {
        TreeModel model;
        TreeIter iter;
        
        TreePath[] treePath = treeView.Selection.GetSelectedRows(out model);
        
        for (int i  = treePath.Length; i > 0; i--)
        {
            model.GetIter(out iter, treePath[(i - 1)]);
    
            string value = (string)model.GetValue(iter, 0);
            Console.WriteLine("Removing: " + value);
    
            TreeIter childIter = treeModelSort.ConvertIterToChildIter(iter);
            listStore.Remove(ref childIter);
        }
    }
