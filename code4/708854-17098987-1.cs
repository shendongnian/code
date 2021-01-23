    var query = context.Grandparent.Select(i => new GrandparentObject
    {
        GrandparentProp1 = i.GrandparentProp1,
        Parents = includeParents
            ? i.Parents.Select(j => new ParentObject
              {
                  ParentProp1 = j.ParentProp1,
                  Children = includeChildren
                      ? j.Children.Select(k => new ChildObject
                        {
                             ChildProp1 = k.ChildProp1
                        }
                      : Enumerable.Empty<Child>()
              }
            : Enumerable.Empty<Parent>()
    };
