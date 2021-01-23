    public IEnumerable<Node> GetSubTree() // Note that this method is lazy
    {
         return new[] { this }
                .Concat(Children.SelectMany(child => child.GetSubTree()));    
    }
