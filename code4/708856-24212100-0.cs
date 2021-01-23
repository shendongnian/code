    var query = context.Grandparent
                       .Select(poco => new 
                        {
                            poco     = poco,
                            parents  = poco.Parents.Where(x => includeParents)
                            children = poco.Children.Where(x => includeChildren) 
                        })
                       .Select(x => new GrandparentObject
    {
        GrandparentProp1 = x.poco.GrandparentProp1,
        Parents          = x.parents.Select(parent => new ParentObject
                           {
                               ParentProp1 = parent .ParentProp1,
                               Children    = x.children.Select(child => new ChildObject
                                             {
                                                 ChildProp1 = child.ChildProp1,
                                             }
                           }
    }
