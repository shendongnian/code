    // Make this a new top-level class
    public static class DispatcherObjectExtensions
    {
        public static void SimpleInvoke(this DispatcherObject dispatcherObject,
                                        Action action)
        {
            dispatcherObject.Dispatcher.Invoke(action);
        }
    }
