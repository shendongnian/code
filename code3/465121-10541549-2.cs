    int myLimit = 10;
    string sentence = "this is a long sentence that needs splitting to fit";
    string[] words = sentence.Split(' ');
    
    StringBuilder newSentence = new StringBuilder();
    
    
    string line = "";
    foreach (string word in words)
    {
        if ((line + word).Length > myLimit)
        {
            newSentence.AppendLine(line);
            line = "";
        }
    
        line += string.Format("{0} ", word);
    }
    
    if (line.Length > 0)
        newSentence.AppendLine(line);
                
    Console.WriteLine(newSentence.ToString());
