    var anotherMethodParams = new List<string>();
    var serviceProvider = new Mock<IServiceProvider>();
    //Setup in Moq seems to be somewhat analogous to Stub in RhinoMocks
    serviceProvider.Setup(sp => sp.AnotherMethod(It.IsAny<string>()))
                   .Callback((string s) => { anotherMethodParams.Add(s); }));
    var x = GetTheObjectThatWillCallServiceProviderAnotherMethod();
    x.GetValueFromStorage("Value1");
    x.GetValueFromStorage("Value2");
    x.GetValueFromStorage("Value3");
    //Assert that the parameter to the second call of AnotherMethod is as expected.
    Assert.AreEqual("Value2", anotherMethodParams[1]);
