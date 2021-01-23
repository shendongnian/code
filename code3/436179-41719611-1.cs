    static void Main(string[] args)
    {
        string str, rev="";
        
        Console.Write("Enter string");
        
        str = Console.ReadLine();
        
        for (int i = str.Length - 1; i >= 0; i--)
        {
            rev = rev + str[i];
        }
        
        if (rev == str)
            Console.Write("Entered string is pallindrome");
        else
            Console.Write("Entered string is not pallindrome");
        
        Console.ReadKey();
    }
