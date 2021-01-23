    [TestMethod]
    public void TestMethod1()
    {
      var container = new UnityContainer();
      // if you absolutely have to use an InjectionConstructor this should do the trick
      // container.RegisterType<IMyClass, MyClass>(
      //   new InjectionConstructor(typeof(Class1), typeof(Class2[])));
      container.RegisterType<IMyClass, MyClass>(
        new InjectionConstructor(typeof(Class1), typeof(Class2[])));
      container.RegisterType<Class2>("1");
      container.RegisterType<Class2>("2");
      container.RegisterType<Class2>("3");
      var myClass = container.Resolve<IMyClass>() as MyClass;
      Assert.IsNotNull(myClass);
      Assert.IsNotNull(myClass.Arg2);
      Assert.AreEqual(3, myClass.Arg2.Length);
    }
    
    interface IMyClass
    {
    }
    class MyClass : IMyClass
    {
      public Class1 Arg1 { get; set; }
      public Class2[] Arg2 { get; set; }
      public MyClass(Class1 arg1, params Class2[] arg2)
      {
        Arg1 = arg1;
        Arg2 = arg2;
      }
    }
    class Class1
    {
    }
    class Class2
    {
    }
