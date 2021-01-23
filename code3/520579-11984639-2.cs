    public class MyClass
    {
    
       public SomeMethod(IWindsorContainer container) 
       {
          var addressService = container.Resolve<IAddressService>();
    
          // Do somthing with 'addressService' ...
       }
    }
