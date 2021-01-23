        const string input = "text1-text2;text3-text4-text5;text6--";
        const string matcher= "(-|;)";
        string[] substrings = Regex.Split(input, matcher); 
        
        StringBuilder builder = new StringBuilder();
        foreach (string entry in substrings)
        {
            builder.Append(entry);
        }
        Console.Out.WriteLine(builder.ToString());
      
