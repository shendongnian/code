    entity.ID = db.Create(
        entity.Name,
        entity.Description,
        entity.InitialStep != null ? (int?)entity.InitialStep.ID : null,
        entity.IsPrivate,
        entity.AllowOnBehalfSubmission,
        new Func<Type, int?> (type => 
        {
            if (type == typeof(SomeType))
                return 1;
            if (type == typeof(AnotherType))
                return 2;
            return null;
        })(entity.GetType())
    );
