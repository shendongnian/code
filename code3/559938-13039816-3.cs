    private ConsoleKey GetChoice()
    {
         Console.Write("Please enter your option choice: ");
         return Console.ReadKey().Key;
    }
    private void DisplayOptions()
    {
         Console.Clear();
         Console.WriteLine("1 : Option 1");
         Console.WriteLine("2 : Option 2");
         Console.WriteLine("3 : Option 3");
         Console.WriteLine("4 : Option 4");
         Console.WriteLine("5 : Option 5");
    }
