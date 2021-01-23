    class Program
        {
            static void Main(string[] args)
            {
                Human h = new Human();
                h.FirstName = "Test";
                h.LastName = "User";
                Console.WriteLine(h.FullName);
                Console.Read();
            }
        }
        class Human
        {
            public string FullName { get { return FirstName + " " + LastName; } }
            public string FirstName;//{ get; set; }
            public string LastName;//{ get; set; }
    
        }
