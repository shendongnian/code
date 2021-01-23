    public interface IUserFacade
    {
       ... // User facade Add, Update, Delete
       IUserStateFacade { set; }    
    }
    public interface IUserStateFacade
    {
       ...
       IUserFacade { set; }
    }
