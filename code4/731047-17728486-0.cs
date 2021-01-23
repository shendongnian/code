    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        // Only rewrite List.Contains()
        if (!node.Method.Name.Equals("Contains", StringComparison.InvariantCultureIgnoreCase))
            return base.VisitMethodCall(node);
        // Extract parameters from original expression
        var sourceList = node.Object;      // The list being searched
        var target = node.Arguments[0];    // The thing being searched for
        var newMethod = this.GetType().GetMethod("InList", BindingFlags.Static | BindingFlags.Public);
        
        // Create new expression
        var newExpression = Expression.Call(newMethod, target, sourceList);
        return newExpression;
    }
