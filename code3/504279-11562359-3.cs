    static void Main(string[] args)
    {
        var dog = new Dog { Age = 4 };
        // This will output to the console
        dog.DisplayDogYears(Console.Out);
        // This will output to the 'sb' StringBuilder
        var sb = new StringBuilder();
        dog.DisplayDogYears(new StringWriter(sb));
    }
