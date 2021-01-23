    var settings = new VisualBasicSettings();
    settings.ImportReferences.Add(new VisualBasicImportReference
    {
        Assembly = typeof(GreetingActivationResult).Assembly.GetName().Name,
        Import = typeof(GreetingActivationResult).Namespace
    }); 
    // ...
    VisualBasic.SetSettings(activity, settings);
    // ... Validate here
