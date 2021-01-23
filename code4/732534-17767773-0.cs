    enum Menu
    {
        Numbers = 1,
        Words = 2,
        Exit = 3,
    }
    static void Main(string[] args)
    {
        bool isValid;
        do
        {
            isValid = true;
            Menu menu = 0;
            int number;
            string word;
            Console.WriteLine("Choose an option from the menu: ");
            Console.WriteLine("1. Numbers ");
            Console.WriteLine("2. Words ");
            Console.WriteLine("3. Exit ");
            switch (menu)
            {
                case Menu.Numbers:
                    List<int> numberarr = new List<int>();
                    Console.WriteLine("Please input as many numbers as you like or type exit");
                    number = int.Parse(Console.ReadLine());
                    numberarr.Add(number);
                    int retInt = functionGetInt(number) 
                    break;
                case Menu.Words:
                    List<string> wordarr = new List<string>();
                    Console.WriteLine("Please input as many numbers as you like");
                    word = Console.ReadLine();
                    wordarr.Add(word);
                    string retString = functionGetString(word);
                    break;
                case Menu.Exit:
                    break;
                default:
                    Console.WriteLine("You have made an invalid selection, try again");
                    isValid = false;
                    break;
            }
        } while (isValid);
    private string functionGetString(string pParmString)
    {
    //code
    return "string";
    }
    private int functionGetInt(int pParmInt)
    {
    //code
    return 0;
    }
      
  }
}
