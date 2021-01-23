    string answer;
    string[] split = five.Split(' ');
    if (split.Length == 2 && split[0].Length > 0 && split[1].StartsWith("?a") && split[1].Length > 3)
    {
        answer = string.Format("{0}{1} {2}", split[0], split[1].Substring(2, 1), split[1].Substring(3));
    }
    else
    {
        answer = five;
    }
