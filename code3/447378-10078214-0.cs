    public interface IUser<T> where T : User
    {
        //some properties here
    
        T ToDerived(User u);
    }
    SalesUser : User, IUser<SalesUser>
    {
        //no properties needed because they exist in the User class
    
        SalesUser ToDerived(User u)
        {
            //code for converting a base User to a derived SalesUser
        }
    }
