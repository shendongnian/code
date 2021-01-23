    class Pro
    {
        public static void fun()
        {
            Console.WindowHeight = 61;
            Console.WriteLine("Welcome to asp .net ");
        }
        static void Main(string[] args)
        {
            Pro.fun();
        }
        // Summary:
        //     Gets the largest possible number of console window rows, based on the current
        //     font and screen resolution.
        //
        // Returns:
        //     The height of the largest possible console window measured in rows.
        public static int LargestWindowHeight { get; }
        
        // Summary:
        //     Gets the largest possible number of console window columns, based on the
        //     current font and screen resolution.
        //
        // Returns:
        //     The width of the largest possible console window measured in columns.
        public static int LargestWindowWidth { get; }
                
