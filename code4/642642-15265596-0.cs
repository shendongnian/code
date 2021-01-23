    List<Tree> parentNodes = new List<Tree>();
    
    using (DBContext context = new DBContext()
    {
        parentNodes = (from query in context.Tree
                       where query.IsSomeWayToIDTheParentNode
                       select query).ToList();
    }
    
    var tree = SomeRecursiveTreeBuilderMethod(parentNodes);
