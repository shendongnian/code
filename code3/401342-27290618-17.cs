        _unityContainer.RegisterType<IGradeType, GradeType>(
           new InjectionConstructor( typeof(ConstructorArgs) ));
        var args1 = new GradeTypeArgs1(gradeTypeStringFromXmlFile); // string
        IGradeType gradeType1 = _unityContainer.Resolve<IGradeType>(
           new ResolverOverride[]{new ParameterOverride("args", args1)});
        var args2 = new GradeTypeArgs2(gradeType); // enum
        IGradeType gradeType2 = _unityContainer.Resolve<IGradeType>(
           new ResolverOverride[]{new ParameterOverride("args", args2)});
