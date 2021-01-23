        using NHibernate.Criterion;
        //...
        var result = session.QueryOver<SomeEntity>()
        	.Where(e => e.SomeProperty
        		.IsLike("xyz", MatchMode.Anywhere)).List().ToList();
