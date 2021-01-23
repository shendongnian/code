    namespace simplecode
    {
        public class Values
        {
    
            public string MyName { get; set; }
    
            public void getName()
            {
                Console.Clear();
                Console.Write("Enter name: ");
                MyName = Console.ReadLine();
            }
        }
    }
