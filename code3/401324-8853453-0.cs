    var continer = new UnityContainer();
    
    continer.RegisterType<IGradeType, GradeType>("stringConstructor", 
        new InjectionConstructor(typeof(string)));
    continer.RegisterType<IGradeType, GradeType>("enumConstructor",
        new InjectionConstructor(typeof(EnumGradeType)));
    
    IGradeType stringGradeType = continer.Resolve<IGradeType>("stringContructor" , 
        new DependencyOverride(typeof(string), "some string"));
    
    IGradeType enumGradeType = continer.Resolve<IGradeType>("enumConstructor", 
        new DependencyOverride(typeof(EnumGradeType), EnumGradeType.Value));
