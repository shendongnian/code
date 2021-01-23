    static void Main()
    {
        string[] words = { "casino", "other word" };
        
        Boolean found = false;
        
        foreach (string word in words)
        {
            if (word == "casino")
            {
                found = true;
                break;
            }
        }
    
        if(!found)
        {
            Console.WriteLine("The word is not found");
        }
        else
        {
            Console.WriteLine("The word is found");
        }
    
        Console.WriteLine("The value of found is: {0}", found);
    
        Console.Read();
    }
