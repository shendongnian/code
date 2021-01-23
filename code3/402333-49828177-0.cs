      class BstNode
        {
            public int data;
            public BstNode(int data)
            {
                this.data = data;
            }
            public BstNode left;
            public BstNode right;
        }
    class Program
                {
                    public static void PreOrderTraversal(BstNode root)
                    {
                        if (root == null) return;
            
                        Console.WriteLine("PreOrderTraversal at node {0}", root.data); // process the root
                        PreOrderTraversal(root.left);// process the left
                        PreOrderTraversal(root.right);// process the right
                    }
            
                    public static void InOrderTraversal(BstNode root)
                    {
                        if (root == null) return;
            
                        InOrderTraversal(root.left);// process the left
                        Console.WriteLine("InOrderTraversal at node {0}", root.data); // process the root
                        InOrderTraversal(root.right);// process the right
                    }
            
                    public static void PostOrderTraversal(BstNode root)
                    {
                        if (root == null) return;
            
                        PostOrderTraversal(root.left);// process the left            
                        PostOrderTraversal(root.right);// process the right
                        Console.WriteLine("PostOrderTraversal at node {0}", root.data); // process the root
                    }
            }
