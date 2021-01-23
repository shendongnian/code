    var list = new List<string>{"the", "me", "cat", "at", "theme", "crying", "them"};
    const string testStr = "themecatcryingthem";
    var words = new Dictionary<int, string>();
    var len = testStr.Length;
    for (int x = 0; x < len; x++)
    {
        int n = len > 28 ? 28 : len;//assuming 28 is the maximum length of an english word
        for(int i = (n - 1); i > x; i--)
        {
            string test = testStr.Substring(x, i - x + 1);
            if (list.Contains(test))
            {
                if (!words.ContainsValue(test))
                {
                    bool found = false;//to check if there's a shorter item starting from same index
                    var key = testStr.IndexOf(test, x, len - x);
                    foreach (var w in words)
                    {
                        if (w.Value.Contains(test) && w.Key != key && key == (w.Key + w.Value.Length - test.Length))
                        {
                            found = true;
                        }
                    }
                    if (!found && !words.ContainsKey(key)) words.Add(key, test);
                }
            }
        }
    }
    words.Values.ToList().ForEach(n=> Console.WriteLine("{0}, ",n));//spit out current values
