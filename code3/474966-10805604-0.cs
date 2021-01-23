     ICriteria crit = Session.CreateCriteria<District>();
            crit.SetProjection(Projections.ProjectionList()
             .Add(Projections.Alias(Projections.Property("Description"), "Description"))
             .Add(Projections.Alias(Projections.Property("Active"), "Active"))
             .Add(Projections.Alias(Projections.Property("Id"), "Id"))
             );
            crit.SetResultTransformer(new NHibernate.Transform.AliasToBeanResultTransformer(typeof(District)));
            return crit.List<District>();
