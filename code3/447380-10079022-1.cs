    public class SalesUser:IUser
    {
       public SalesUser(User user)
       {
          //initialize this instance using the User object
       }
    }
    //the above allows you to do this:
    mySalesUser = new SalesUser(myUser);
    //and it also allows the definition of a method like this,
    //which requires the generic to be an IUser and also requires a constructor with a User
    public void DoSomethingWithIUser<T>(User myUser) where T:IUser, new(User)
    { 
        //...which would allow you to perform the "conversion" by creating a T:
        var myT = new T(myUser);
    }
