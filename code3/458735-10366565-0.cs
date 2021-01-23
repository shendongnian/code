    public void displayTree(Node root)
    {
        if(root == null) return;
        displayTree(root.left);
        System.Console.Write(root.data + " ");
        displayTree(root.right);
    }
