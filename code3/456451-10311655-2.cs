    public interface IGetNames
    {
        List<string> GetNames();
    }
    // One option is to redefine the entire interface and use 
    // explicit interface implementations in your concrete classes.
    public interface IGetMoreNames
    {
        List<string> GetNames();
        List<string> GetMoreNames();
    }
    // Another option is to inherit.
    public interface IGetMoreNames : IGetNames
    {
        List<string> GetMoreNames();
    }
    // A final option is to only define new stuff.
    public interface IGetMoreNames 
    {
        List<string> GetMoreNames();
    }
