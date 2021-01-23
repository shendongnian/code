          Parent parent = null;
          var countMatchesPerParent = 
            QueryOver.Of<Child>()
              .WhereRestrictionOn(x => x.Name).IsIn(names)
              .JoinQueryOver<Parent>(x => x.Parents)
              .Where(x => x.Id == parent.Id)
              .Select(Projections.RowCount());
          var parentsWithMinimalMatches =
            session.QueryOver(() => parent)
              .WithSubquery.WhereValue(names.Length).Le(countMatchesPerParent)
              .List();
