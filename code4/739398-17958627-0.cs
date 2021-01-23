    static void Main(string[] args)
    {
        // Specifying int here ...
        UnlimitedGenericArray<int> oArray = new UnlimitedGenericArray<int>(); 
        while(true)
        {
         string userInput = Console.ReadLine();
		 int number = int.Parse(userInput);
         // ... therefore we know that the method below requires an int
         oArray.InsertItem(number);
        }
    }
