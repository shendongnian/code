    var container = new UnityContainer();
    container.AddNewExtension<EnrichmentExtension>();
    container.RegisterType<SomeSettings>(new Enrichment<SomeSettings>((original, ctx) =>
      {
        ctx.NewBuildUp<ISettingsProvider>().PopulateSettings(original);
      }));
