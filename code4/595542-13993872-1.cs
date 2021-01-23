    List<string> stringList; // populate how you see fit
    string text="I want an apple";
    
    public static string getItem(string text)
    {
        foreach(var s in stringList)
        {
            if(text.Contains(s))
            {
                // do stuff here
            }
        }
    }
