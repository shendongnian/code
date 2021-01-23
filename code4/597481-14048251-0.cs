    public static class MyTrace
    {
        public static event Action<string> MessageReceived;
        internal static void Broadcast(string message)
        {
            if (MessageReceived != null) MessageReceived(message);
        }
    }
