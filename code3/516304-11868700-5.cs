    class TreeNode<T> {
        public T Content {get; set;}
        public IEnumerable<TreeNode<T>> Dependents {get;set;}
    }
    foreach (TreeNode node in TreeUtils.GetAllNodes(root, n => n.Dependents)) {
        Console.WriteLine(node.Content);
    }
