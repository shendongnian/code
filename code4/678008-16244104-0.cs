        public IEnumerable<Node> TraverseTree(Node root)
        {
            if (root.Children != null)
            {
                foreach (var child in root.Children)
                {
                    var nodes = TraverseTree(child);
                    foreach (var node in nodes)
                    {
                        yield return node;
                    }
                }
            }
            yield return root;
        }
