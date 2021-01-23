    public static class RequestHandler
    {
        public static void Handle<T>(T request)
        {
            Locator.Instance.GetService<IModificationRequstHandler<T>>().Handle(req);
        }
    }
