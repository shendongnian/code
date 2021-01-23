    static void Main(string[] args)
    {
        Mother mary = new Mother("Mary");
        Child bobby = new Child("Bobby");
        bobby.MyMother = mary;
        Console.WriteLine(bobby.WhoAreYou());
        Console.ReadLine();
    }
