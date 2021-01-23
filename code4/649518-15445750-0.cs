     int columnWidth= 8;
        string sentence = "How can I format a C# string to wrap to fit a particular column width?";
        string[] words = sentence.Split(' ');
    
    StringBuilder newSentence = new StringBuilder();
    
    
    string line = "";
    foreach (string word in words)
    {
        if ((line + word).Length > columnWidth)
        {
            newSentence.AppendLine(line);
            line = "";
        }
    
        line += string.Format("{0} ", word);
    }
    
    if (line.Length > 0)
        newSentence.AppendLine(line);
    
    Console.WriteLine(newSentence.ToString());
