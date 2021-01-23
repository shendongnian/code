    var query = context.Grandparent.Select(i => new GrandparentObject
    {
        GrandparentProp1 = i.GrandparentProp1 ,
        Parents = i.Parents
            .Where(_ => includeParents)
            .Select(j => new ParentObject
        {
            ParentProp1 = j.ParentProp1,
            Children = j.Children
                .Where(_ => includeChildren)
                .Select(k => new ChildObject
            {
                ChildProp1 = k.ChildProp1,
            }
        }
    }
