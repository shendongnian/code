    public void PopulateBottles()
    {
        Console.WriteLine("Please enter the information for 5 bourbons:");
        for (int runs = 0; runs < 5; runs ++)
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
