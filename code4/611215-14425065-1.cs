    interface IPlugin
    {
        string Username { get; }
    }
    class Imp : IPlugin
    {
        string IPlugin.Username
        {
            get { return "Taylor"; }
        }
    }
