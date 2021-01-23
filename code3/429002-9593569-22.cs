          Parent parent = null;
          var parentSubQuery = QueryOver.Of<Child>()
            .WhereRestrictionOn(x => x.Name).IsIn(names)
            .JoinQueryOver(x => x.Parents, () => parent)
            .Where(Restrictions.Ge(Projections.Count(() => parent.Id), names.Length))
            .Select(Projections.Group(() => parent.Id));
          var parents = session.QueryOver<Parent>()
            .WithSubquery.WhereProperty(x => x.Id).In(parentSubQuery)
            .List();
