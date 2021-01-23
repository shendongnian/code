    static public class WinApi
    {
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
        
        public static int RegisterWindowMessage(string format, params object[] args)
        {
            string message = String.Format(format, args);
            return RegisterWindowMessage(message);
        }
    }
