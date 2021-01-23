        public class TreeNode
        {
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
        }
        static void Main(string[] args)
        {
            var root = new TreeNode { Left = new TreeNode {Left = new TreeNode() }, 
                                      Right = new TreeNode() };
   
        }
