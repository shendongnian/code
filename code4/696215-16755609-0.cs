    List<string> GreetingKeywords;
    GreetingKeywords.Add("hello"); // ...
    
    List<string> MathKeywords;
    MathKeywords.Add("math"); // ...
    
    foreach (var word in dicList)
    {
      if (GreetingKeywords.Contains(word))
        { Greetings(); }
      if (MathKeywords.Contains(word))
        { Maths(); }
    }
