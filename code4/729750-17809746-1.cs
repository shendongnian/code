        char[] characters = "WatiN".ToCharArray();
        
        foreach(var character in characters)
        {
            ie.TextField(Find.ByName("q")).TypeText(character);
            Thread.Sleep(1000);
        }
