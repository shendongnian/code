    public interface IControllerBaseService 
    {
       IUserService UserService {get;set;}
       ShoppingMode ShoppingMode {get;set;}
       ...
    }
    public abstract class ControllerBase : Controller, IControllerBaseService 
    {
       public IUserService UserService {get;set;} // this is injected by IoC
       public ShoppingMode ShoppingMode 
       {
          get 
          {
               return UserService.CurrentShoppingMode; // this uses injected instance to get value
          }
       ...
    }
