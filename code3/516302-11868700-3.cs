    class TreeNode<T> {
        T Content {get; set;}
        IEnumerable<TreeNode<T>> Dependsnts {get;set;}
    }
    foreach (TreeNode node in TreeUtils.GetAllNodes(root, n => n.Dependents) {
        Console.WriteLine(node.Content);
    }
