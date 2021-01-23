    string Source = "{ TEST test } test { test test} {test test } { 123 } test test";
    List<string> Result = new List<string>();
    StringBuilder Temp = new StringBuilder();
    bool inBracket = false;
    foreach (char c in Source)
    {
        switch (c)
        {
            case (char)32:       //Space
                if (!inBracket)
                {
                    Result.Add(Temp.ToString());
                    Temp = new StringBuilder();
                }
                break;
            case (char)123:     //{
                inBracket = true;
                break;
            case (char)125:      //}
                inBracket = false;
                break;
        }
        Temp.Append(c);
    }
    if (Temp.Length > 0) Result.Add(Temp.ToString());
