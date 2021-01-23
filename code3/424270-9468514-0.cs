    class Program
    {
        static void Main(string[] args)
        {
            string[] testData = new string[] { "aa", "bbb", "cccccc", "d", "ee", "ffffff", "ggggg" };
            var expected = new BinaryNode<string>("ffffff");
            IBinaryTree<string> tree = new BinaryTree<string>();
            tree.Build(testData);
    
            var result = tree.Root.Traverse(expected, new List<IBinaryNode<string>>());
        }
    }
