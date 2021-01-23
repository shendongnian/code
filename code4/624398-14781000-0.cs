    public static class NodeExtensions
    {
        public static MyNode ToMy( this Node node ) 
        {
            var result = node.Transform();
            result.Children = node.Children.Select( ToMy ).ToList();
        }
        public static Node FromMy( this MyNode node ) 
        {
            var result = node.Transform();
            result.Children = node.Children.Select( ToMy ).ToList();
        }
        public static MyNode Transform( this Node node )
        {
            // TODO code to transform any single node here
        }
        public static Node Transform( this MyNode node )
        {
            // TODO code to transform any single node here
        }
    }
