    int myLimit = 10;
    string sentence = "this is a long sentence that needs splitting to fit";
    string[] words = sentence.Split(new char[] { ' ' });
    IList<string> sentenceParts = new List<string>();
    sentenceParts.Add(string.Empty);
    
    int partCounter = 0;
    
    foreach (string word in words)
    {
        if ((sentenceParts[partCounter] + word).Length > myLimit)
        {
            partCounter++;
            sentenceParts.Add(string.Empty);
        }
    
        sentenceParts[partCounter] += word + " ";
    }
    
    foreach (string x in sentenceParts)
        Console.WriteLine(x);
