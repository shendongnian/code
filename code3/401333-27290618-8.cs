        _unityContainer.RegisterType<IGradeType, GradeType>(
           new InjectionConstructor( typeof(ConstructorArgs) ));
        var args1 = new GradeTypeArgs1(gradeTypeStringFromXmlFile);
        IGradeType gradeType1 = this.YouUnityContainer.Resolve<IGradeType>(
           new ResolverOverride[]{new ParameterOverride("args", args1)});
        var args2 = new GradeTypeArgs2(gradeType);
        IGradeType gradeType2 = this.YouUnityContainer.Resolve<IGradeType>(
           new ResolverOverride[]{new ParameterOverride("args", args2)});
