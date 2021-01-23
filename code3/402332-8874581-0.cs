    public void recursiveInorder(BinaryTreeNode root)
    {
        if (root.Left != null)
        {
            recursiveInorder(root.Left);
        }
        Console.Write(root.Data.ToString());
        if (root.Right != null)
        {
            recursiveInorder(root.Right);
        }
    }
