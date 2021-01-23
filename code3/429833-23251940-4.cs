    public static class ConsoleWriteExtensions
    {
        public static void wl(this string format, params object[] parms){
            Console.WriteLine(format, parms);
        }
    }
    "{0} -> {1}".wl("Mili",123.45); // prints Mili -> 123.45
