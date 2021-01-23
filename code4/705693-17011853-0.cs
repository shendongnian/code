    public static System.Threading.Thread Network;
    static void Main()
    {
        Network = new System.Threading.Thread(NetworkMethod);  // Insert Name of your method here
        Network.Start();
        // Run your normal application
    }
    static void NetworkMethod()
    {
        // Do stuff that would block the UI
    }
