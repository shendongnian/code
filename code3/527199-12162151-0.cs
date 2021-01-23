    private void RemoveDuplicatesFromTree(Node root)
    {
        List<Node> nodesToBeremoved = new List<Node>();
        root.Children.ForEach(p =>
            {
                if (!nodesToBeremoved.Contains(p))
                {                        
                    nodesToBeremoved.AddRange(root.Children.Where(q => q.Name == p.Name && q != p));
                }
            });
        for (int i = 0; i < nodesToBeremoved.Count; i++)
        {
            root.Children.Remove(nodesToBeremoved[i]);
        }
        if (root.Children != null && root.Children.Count > 0)
        {
            root.Children.ForEach(t => this.RemoveDuplicatesFromTree(t));
        }
    
    }
