    public enum Code { Wakeup, ShutDown, Notification1, Notification2 };
    public enum Type { Control, Notification, Invalid }
    public static class CodeCheck
    {
        public static bool IsControl( Code code )
        {
            return code == Code.Wakeup || code == Code.ShutDown;
        }
        public static bool IsNotification( Code code )
        {
            return code == Code.Notification1 || code == Code.Notification2;
        }
        public static Type GetType( Code code )
        {
            if ( IsControl( code ) )
                return Type.Control;
            if ( IsNotification( code ) )
                return Type.Notification;
            return Type.Invalid;
        }
    }
