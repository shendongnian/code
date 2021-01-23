    // prepare our property overriding type descriptor
    PropertyOverridingTypeDescriptor ctd = new PropertyOverridingTypeDescriptor(TypeDescriptor.GetProvider(_settings).GetTypeDescriptor(_settings));
    
    // iterate through properies in the supplied object/type
    foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(_settings))
    {
        // for every property that complies to our criteria
        if (pd.Name.EndsWith("ConnectionString"))
        {
            // we first construct the custom PropertyDescriptor with the TypeDescriptor's
            // built-in capabilities
            PropertyDescriptor pd2 =
                TypeDescriptor.CreateProperty(
                    _settings.GetType(), // or just _settings, if it's already a type
                    pd, // base property descriptor to which we want to add attributes
                        // The PropertyDescriptor which we'll get will just wrap that
                        // base one returning attributes we need.
                    new EditorAttribute( // the attribute in question
                        typeof (System.Web.UI.Design.ConnectionStringEditor),
                        typeof (System.Drawing.Design.UITypeEditor)
                    )
                    // this method really can take as many attributes as you like,
                    // not just one
                );
            // and then we tell our new PropertyOverridingTypeDescriptor to override that property
            ctd.OverrideProperty(pd2);
        }
    }
    // then we add new descriptor provider that will return our descriptor istead of default
    TypeDescriptor.AddProvider(new TypeDescriptorOverridingProvider(ctd), _settings);
