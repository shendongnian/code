    public class MyConsole
    {
        public static event Action<string> TextWritten;
        public static void Write(object obj)
        {
            string text = (obj ?? "").ToString();
            if (TextWritten != null)
                TextWritten(text);
        }
    
        public static void WriteLine(object obj)
        {
            Write(obj + "\n");
        }
    }
