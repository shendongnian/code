    var list = new List<string>{"the", "me", "cat", "at", "theme"};
    const string testStr = "themecat";
    var words = new List<string>();
    var len = testStr.Length;
    for (int x = 0; x < len; x++)
    {
        for(int i = (len - 1); i > x; i--)
        {
            string test = testStr.Substring(x, i - x + 1);
            if (list.Contains(test) && !words.Contains(test))
            {
                words.Add(test);
            }
        }
    }
    words.ForEach(n=> Console.WriteLine("{0}, ",n));//spit out current values
