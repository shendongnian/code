        public static IEnumerable<T> DepthFirst<T>(T node, 
                                                   Func<T, IEnumerable<T>> getChildren, 
                                                   HashSet<T> visitedNodes)
        {
            return getChildren(node)
                  .Where(visitedNodes.Add)
                  .SelectMany(child => DepthFirst(child, getChildren, visitedNodes))
                  .Concat(new[] { node });
        }
        
        public static IEnumerable<T> DepthFirst<T>(T root, 
                                                   Func<T, IEnumerable<T>> getChildren) 
        {
            return DepthFirst(root, getChildren, new HashSet<T> {root});
        }
