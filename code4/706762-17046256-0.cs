    public enum Type { Wakeup, ShutDown, Notification1, Notification2 };
    public static class TypeCheck
    {
        public static bool IsControl( Type type )
        {
            return type == Type.Wakeup || type == Type.ShutDown;
        }
        public static bool IsNotification( Type type )
        {
            return type == Type.Notification1 || type == Type.Notification2;
        }
    }
