    // Register a named type mapping
    myContainer.RegisterType<IMyObject, MyRealObject1>(MyEnum.Value1.ToString());
    myContainer.RegisterType<IMyObject, MyRealObject2>(MyEnum.Value2.ToString());
    myContainer.RegisterType<IMyObject, MyRealObject3>(MyEnum.Value3.ToString());
    // Following code will return a new instance of MyRealObject1
    var mySubclass = myContainer.Resolve<IMyObject>(myEnumValue1.ToString());
