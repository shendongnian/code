    class Program
        {
            [Flags]
            public enum Answer
            {
                Yes = 1,
                No = 2,
                Choice1 = 1,
                Choice2 = 2,
                Choice3 = 4,
                Choice4 = 8,
            }
    
            static void Main(string[] args)
            {
    
                int SomeInt = (int)Answer.Choice1;
    
                Console.WriteLine((Answer)SomeInt);
    
                Console.ReadKey();
            }
        }
