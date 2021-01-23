    static void Main()
    {
        // Build a list of vowels up front:
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        Console.WriteLine("Enter a Sentence");
        string sentence = Console.ReadLine().ToLower();
        
        int total = sentence.Count(c => vowels.Contains(c));
        Console.WriteLine("Your total number of vowels is: {0}", total);
        Console.ReadLine();
    }
