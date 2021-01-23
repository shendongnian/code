    static void Main()
    {
        string[] words = { "casino", "other word" };
        
        Boolean found = false;
        
        foreach (string word in words)
        {
            if (word == "casino")
            {
                found = true;
                goto Found;
            }
        }
    
        if(!found)
        {
            goto NotFound;
        }
    
        Found: { Console.WriteLine("The word is found"); goto Continue; }
        NotFound: { Console.WriteLine("The word is not found"); }
    
        Continue:
        Console.WriteLine("The value of found is: {0}", found);
    
        Console.Read();
    }
