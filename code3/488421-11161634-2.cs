    public IEnumerable<Node> GetNodeAndDescendants() // Note that this method is lazy
    {
         return new[] { this }
                .Concat(Children.SelectMany(child => child.GetSubTree()));    
    }
