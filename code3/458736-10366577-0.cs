    public void displayTree(Node root)
    {
         if (root == null)
           return;
         displayTree(root.left);
         Console.Write(...);
         displayTree(root.right);
    }
