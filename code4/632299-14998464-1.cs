    var criteria = session.CreateCriteria<Parent>()
     .Add(Restrictions.In("FirsParentProperty", new int[] {1, 2 })) // WHERE
     .Add(Restrictions.... // the second
     .Add(Restrictions.... // the third
     // no filter to match children
     .Add(Subqueries.PropertyIn("ID", sub)); // Parent.ID in (select
     // now paging just over Parent table....
     .SetFirstResult(100) // skip some rows
     .SetMaxResults(20)   // take 20
    
    var result = criteria.List<Parent>();
