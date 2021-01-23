     container.Register<IEngine1, Engine1>();
     var theOneAndOnlyConfig = new AllEnginesConfig() {}; // properly initialized, of course
     container.RegisterInstance<IEngine1Config>(theOneAndOnlyConfig); 
     container.RegisterInstance<IEngine2Config>(theOneAndOnlyConfig); 
     // ...
