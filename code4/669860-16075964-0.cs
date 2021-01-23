    EntityMap()
    {
        Id(x => x.Id);
        HasMany(x => Texts)
            .KeyColumn("entity_id")
            .ApplyFilter("languageFilter", "language_id = :lid");
    }
    
    EntityTextClass()
    {
        CompositeId()
            .KeyReference(x => x.Entity, "entity_id")
            .KeyProperty(x => x.LanguageId);
    }
    // at beginning of request
    session.EnableFilter("languageFilter").SetParameter(":lid", languageId);
    var entity = session.Query<Entity>().Fetch(e => e.Texts).First();
    string text = entity.Texts.First();  // could be a seperate property
