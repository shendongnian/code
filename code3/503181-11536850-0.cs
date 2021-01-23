    public static class ActionExtension
    {
        public static void SafeInvoke<T>(this Action<T> action, T arg)
        {
            var temp = action;
            if (temp != null)
            {
                temp(arg);
            }
        }
    }
    public event Action<string> InterestingEvent;
    // event invoker
    InterestingEvent.SaveInvoke("Boo!");
    
    
