            var tagCriteria = new SQLCriterion(
                new SqlString("{alias}.Id IN (SELECT ID_Item FROM Items_Tags WHERE Tag LIKE ?)"),
                new[] {searchKey + "%"},
                new[] {NHibernateUtil.String}
                );
            session
                .QueryOver<Item>(() => i)
                .JoinAlias(x => x.Group, () => g, JoinType.InnerJoin)
                .Where(
                    new Disjunction()
                        .Add(Restrictions.On(() => p.Description).IsInsensitiveLike(searchKey, MatchMode.Anywhere))
                        .Add(Restrictions.On(() => g.Description).IsInsensitiveLike(searchKey, MatchMode.Start))
                        .Add(tagCriteria)
                )
                .Take(maxResults)
                .Future();
