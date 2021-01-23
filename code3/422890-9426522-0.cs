    var container = new UnityContainer();
    container.RegisterType<IInterface, MyFirstClass>("first");
    container.RegisterType<IInterface, MySecondClass>("second");
    container.RegisterType<Class1>(new InjectionConstructor(new ResolvedParameter(typeof(IInterface), "first")));
    container.RegisterType<Class2>(new InjectionConstructor(new ResolvedParameter(typeof(IInterface), "second")));
    var class1 = container.Resolve<Class1>();
    Assert.IsInstanceOfType(class1.MyClass, typeof(MyFirstClass));
    var class2 = container.Resolve<Class2>();
    Assert.IsInstanceOfType(class2.MyClass, typeof(MySecondClass));
    
    public class MyFirstClass : IInterface
    {
    }
    
    public class MySecondClass : IInterface
    {
    }
    
    public interface IInterface
    {
    }
    
    public class Class1
    {
      public IInterface MyClass { get; set; }
      public Class1(IInterface myClass)
      {
        MyClass = myClass;
      }
    }
    public class Class2
    {
      public IInterface MyClass { get; set; }
      public Class2(IInterface myClass)
      {
        MyClass = myClass;
      }
    }
