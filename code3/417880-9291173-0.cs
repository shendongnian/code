    var assembliesWithPluginBaseInThem = AppDomain.CurrentDomain.GetAssemblies()
        .Where( x => 
           x.GetTypes().Where( y =>
               y.BaseType == typeof(PluginBase) &&
               y.GetConstructors().Any( z =>
                  z.GetParameters().Count() == 1 && // or maybe you don't want exactly 1 param?
                  z.GetParameters().All( a => a.IsInterface )
               )
           )
        )
