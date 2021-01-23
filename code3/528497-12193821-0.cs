    Console.WriteLine("Enter the name of this new person.");
    string name = Convert.ToString(Console.ReadLine());
    
    Console.WriteLine("Now their age.");
    string age = Convert.ToInt32(Console.ReadLine());
    
    peopleList.Add(new Person(name, age));
