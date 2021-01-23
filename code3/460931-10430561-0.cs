    public static class Tree<N>
        where N : Tree<N>.Node
    {
        public class Node
        {
            public String Name { get; set; }
            public List<N> Children { get; set; } 
        }
        public static void NavigateAndExecute(N root, Action<N> actionToExecute)
        {
            if (root == null)
                return;
            actionToExecute(root);
            if (root.Children == null || root.Children.Count == 0)
                return;
            NavigateAndExecute(root.Children, actionToExecute);
        }
        public static void NavigateAndExecute(List<N> root, Action<N> actionToExecute)
        {
            if (root == null || root.Count == 0)
                return;
            foreach (var node in root)
            {
                NavigateAndExecute(node, actionToExecute);
            }
        } 
    }
    public class Node2 : Tree<Node2>.Node
    {
        public string Name2 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var root = new Node2();
            Tree<Node2>.NavigateAndExecute(root, n => {
                Console.WriteLine(n.Name2);
            });
        }
    }
