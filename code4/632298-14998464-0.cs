    var sub = DetachedCriteria
     .For<Child>()
     .Add(Restrictions.In("FirsChildProperty", new int[] {1, 2 })) // WHERE
     .Add(Restrictions.... // Second
     .SetProjection(Projections.Property("Parent.ID")); // Parent ID as a SELECT clause
