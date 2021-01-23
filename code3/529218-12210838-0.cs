    session
        .QueryOver<Item>(() => i)
        .JoinAlias(x => x.Group, () => g, JoinType.InnerJoin)
        .JoinAlias(x => x.Tags, () => tag, JoinType.LeftOuterJoin) //left outher join because it is possible for an item to have no tags at all.
        .Where(
            new Disjunction()
                .Add(Restrictions.On(() => p.Description).IsInsensitiveLike(searchKey, MatchMode.Anywhere))
                .Add(Restrictions.On(() => g.Description).IsInsensitiveLike(searchKey, MatchMode.Start))
                .Add(Restrictions.On(() => tag.Tag).IsInsensitiveLike(searchKey, MatchMode.Start)) //this condition throws an exception
        )
        .Take(maxResults)
        .Future();
