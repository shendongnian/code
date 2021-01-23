    protected override void Configure()
    {
        CreateMap<GlossaryModel, Glossary>()
            .ReverseMap();
        //....... etc
    }
