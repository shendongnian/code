    public interface IUser
    {
        string Username { get; }
    }
    
    public class MyPrivateInfo : IUser
    {
        public string Username
        {
            get;
            private set;
        }
    }
    
    public class MyLibInfo : IUser
    {
        public string Username
        {
            get;
            internal set;
        }
    }
