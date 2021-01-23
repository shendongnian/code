    queryover = queryover
        .Select(
            Projections.Group<Foo>(c => c.ID),
            Projections.Sum(
                Projections.Conditional(
                    Restrictions.Where<Foo>(f => f.myProperty == MyEnum.Two),
                    Projections.Constant(1),
                    Projections.Constant(0))),
            Projections.Sum(
                Projections.Conditional(
                    Restrictions.Where<Foo>(f => f.myProperty == MyEnum.Three),
                    Projections.Constant(1),
                    Projections.Constant(0))));
