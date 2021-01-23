    SecurityDomainContext.Current.Load<YourObjectType>(
        SecurityDomainContext.Current.GetBUGroupsCustomQuery(),
        LoadBehavior.MergeIntoCurrent,
        loadOperation =>
        {
            var results = context.Comments.Where(
                entity => !loadOperation.Entities.Contains(entity)).ToList();
            results.ForEach(entity => context.Comments.Detach(entity));
        }, null);
