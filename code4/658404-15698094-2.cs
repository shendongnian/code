    public List<TreeNode<Category>> ConstructCategories(List<Category> categories)
    {
        var groups = categories.GroupBy(e => e.ParentCategoryID);
        var rootGroup = groups.Single(e => e.Key == null);
        var categories = List<TreeNode<Category>>();
        foreach (var category in rootGroup)
        {
            // Create and fill category
            var node = new TreeNode<Category>(category);
            ConstructChildrenCategories(node, groups);
            categories.Add(node);
        }
    }
    public void ConstructChildrenCategories(TreeNode<Category> node, IEnumerable<IGrouping<Category>> groups)
    {
        var group = groups.Single(e => e.Key == node.Item.CategoryID);
        foreach (var category in group)
        {
            // Create and fill category
            var childNode = new TreeNode<Category>(category);
            ConstructChildrenCategories(childNode, groups);
            // We could do this automatically in both methods.
            childNode.SetParent(node.Item);
            node.AddChild(childNode);
        }
    }
