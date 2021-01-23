       public static class I
     {
        public string preclude = ">";
        public static void WriteLine(string message)
        {
         Console.WriteLine(preclude+message);
        }
        public static void ReadLine()
        {
         Console.Write(preclude);Console.ReadLine();
        }
     }
