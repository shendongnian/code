    static void RemoveDuplicates(ref Node root)
    {
            Dictionary<string, Node> nonDuplicates = new Dictionary<string, Node>();
                        
            Action<Node> traverseTree = null;
            traverseTree = (x) =>
            {
                var compareId = x.CompareId;
                if (nonDuplicates.ContainsKey(compareId)) // if there is a duplicate 
                {
                    x.Parent.Children.Remove(x); // remove node
                }
                else
                {
                    nonDuplicates.Add(compareId, x);                    
                }
                // cannot use foreach loop because removing a node will result in exception
                // keep traversing the tree
                for (var i = x.Children.Count - 1; i >= 0; i--)
                    traverseTree(x.Children[i]);
            };
            traverseTree(root);
    }
