    class Bourbon
        {
    
            private Bourbon[] bBottles = new Bourbon[5];
    
            private string name;
    
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            private string distillery;
    
            public string Distillery
            {
                get { return distillery; }
                set { distillery = value; }
            }
            private int age;
    
            public int Age
            {
                get { return age; }
                set { age = value; }
            }
    
            public Bourbon(string name, string distillery, int age)
            {
                Name = name;
                Distillery = distillery;
                Age = age;
            }
        
            public void PopulateBottles()
            {
                Console.WriteLine("Please enter the information for 5 bourbons:");
                for (int runs = 0; runs < 5; runs++)
                {
                    Console.WriteLine("Name:");
                    var name = Console.ReadLine();
                    Console.WriteLine("Distillery:");
                    var distillery = Console.ReadLine();
                    Console.WriteLine("Age:");
                    var age = int.Parse(Console.ReadLine());
                    var bourbon = new Bourbon(name, distillery, age);
                    bBottles[runs] = bourbon;
                }
            }
        }
