    public interface IServiceRepository
    {
        User GetUser(int id);
        User GetUser(string email);
        User GetUser(string email, byte[] password);
        //SkipCode
    }
