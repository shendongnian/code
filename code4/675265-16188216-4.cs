    public class UserServiceConsumer:IUserServiceConsumer{
      public UserServiceConsumer(IUserServiceFactory userServiceFactory){
        this.userServiceFactory = userServiceFactory;
      }
      IUserServiceFactory userServiceFactory;
      
      public void ConsumeFactory(User user){
        //do some validation maybe
        userServiceFactory.DoSomething(user);
      }
    }
