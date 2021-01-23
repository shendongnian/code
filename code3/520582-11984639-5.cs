    public class MyClass
    {
      public SomeMethod(IWindsorContainer container)
      {
         container.Register( Component.For<IAddressService>().ImplementedBy<AddressService>());
      }
    }
