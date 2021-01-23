    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MessageHandlers.Add(new MessageHandler1());
            // Other code not shown...
        }
    }
