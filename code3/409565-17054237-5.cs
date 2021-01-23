    // Using a NAMED parameter:
    builder.RegisterType<ConfigReader>()
           .As<IConfigReader>()
           .WithParameter("configSectionName", "sectionName");// parameter name, parameter value. It's the same of this: new NamedParameter("configSectionName", "sectionName")
    
    // Using a TYPED parameter:
    builder.RegisterType<ConfigReader>()
           .As<IConfigReader>()
           .WithParameter(new TypedParameter(typeof(string), "sectionName"));
    
    // Using a RESOLVED parameter:
    builder.RegisterType<ConfigReader>()
           .As<IConfigReader>()
           .WithParameter(
             new ResolvedParameter(
               (pi, ctx) => pi.ParameterType == typeof(string) && pi.Name == "configSectionName",
               (pi, ctx) => "sectionName"));
