    static void Main(string[] args)
    {
        // This will output to the console
        var consoleDog = new Dog() { Age = 4 };
        consoleDog.DisplayDogYears(Console.Out);
        // This will output to the 'sb' StringBuilder
        var sb = new StringBuilder();
        var stringWriterDog = new Dog() { Age = 4 };
        stringWriterDog.DisplayDogYears(new StringWriter(sb));
    }
