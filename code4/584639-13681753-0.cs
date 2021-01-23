    string[] str = new[] { "null", "String 1", "String 2", "String 3", "null", "String 4", "String 5", "String 6", "null", "String 7", "String 8", "String 9" };
    var newStr = new List<string>();
    for (int i = 0; i < str.Length; i++)
    {
        string current = str[i];
        if (current == "null")
        {
            int index = Array.IndexOf(str, "null", i + 1, str.Length - (i + 1));
            if (index >= 0)
            {
                newStr.Add(string.Join(" ", str.Skip(i + 1).Take(index - 1 - i)));
                i = index - 1;
            }
            else
            {
                if (i != str.Length - 1)
                    newStr.Add(string.Join(" ", str.Skip(i + 1).Take(str.Length - i)));
                break;
            }
        }
    }
