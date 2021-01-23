    RepositoryLocalObject context = null;
    if (package.GetByName(Package.ComponentName) == null)
        context = (RepositoryLocalObject)engine.GetObject(
                   package.GetByName(Package.ComponentName));
    else
        context = (RepositoryLocalObject)engine.GetObject(
                   package.GetByName(Package.ComponentName));
    Repository contextPublication = context.ContextRepository;
    if (contextPublication.Metadata == null) return;
    ItemFields metadata = 
         new ItemFields(contextPublication.Metadata, contextPublication.MetadataSchema);
    if (!metadata.Contains("MyLoginComponentField")) return;
    ComponentLinkField myLoginComponentField = (ComponentLinkField)metadata["MyLoginComponentField"];
    Component loginTarget = myLoginComponentField.Value;
    UsingItemsFilter filter = new UsingItemsFilter(engine.GetSession())
                                    {
                                        InRepository = contextPublication, 
                                        ItemTypes = new[] {ItemType.Page}
                                    };
    foreach (Page page in component.GetUsingItems(filter))
    {
        string url = page.PublishLocationUrl;
    }
