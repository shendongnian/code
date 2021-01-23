    //Simple Regex for strings
    string StringRegex = "\"(?:[^\"\\\\]|\\\\.)*\"";
    
    //Simple Regex for comments
    string CommentRegex = @"//.*|/\*[\s\S]*\*/";
    
    //Simple Regex for keywords
    string KeywordRegex = @"\b(?:new|var|string)\b";
    
    //Create a dictionary relating token types to regexes
    Dictionary<string, string> Regexes = new Dictionary<string, string>()
    {
        {"String", StringRegex},
        {"Comment", CommentRegex},
        {"Keyword", KeywordRegex}
    };
    
    //Define a string to tokenize
    string input = "string myString = \"Hi! this is my new string!\"//Defines a new string.";
    
    
    //Lexer steps:
    //1). Find all of the matches from the regexes
    //2). Convert them to tokens
    //3). Order the tokens by index then priority
    //4). Loop through each of the tokens comparing
    //    the current match with the next match,
    //    if the next match is partially contained by this match
    //    (or if they both occupy the same space) remove it.
    
    
    //** Sorry for the complex LINQ expression (not really) **
    
    //Match each regex to the input string(Step 1)
    var matches = Regexes.SelectMany(a => Regex.Matches(input, a.Value)
    //Cast each match because MatchCollection does not implement IEnumerable<T>
    .Cast<Match>()
    //Select a new token for each match(Step 2)
    .Select(b => 
            new
            {
                Index = b.Index,
                Value = b.Value,
                Type = a.Key //Type is based on the current regex.
            }))
    //Order each token by the index (Step 3)
    .OrderBy(a => a.Index).ToList();
    
    //Loop through the tokens(Step 4)
    for (int i = 0; i < matches.Count; i++)
    {
        //Compare the current token with the next token to see if it is contained
        if (i + 1 < matches.Count)
        {
            int firstEndPos = (matches[i].Index + matches[i].Value.Length);
            if (firstEndPos > matches[(i + 1)].Index)
            {
                //Remove the next token from the list and stay at
                //the current match
                matches.RemoveAt(i + 1);
                i--;
            }
        }
    }
    
    //Now matches contains all of the right matches
    //Filter the matches by the Type to single out keywords from comments and
    //string literals.
    foreach(var match in matches)
    {
        Console.WriteLine(match);
    }
    Console.ReadLine();
