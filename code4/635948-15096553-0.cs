    Regex needle = new Regex("\[letter\]");
    string haystack = "123456[letter]123456[letter]123456[letter]";
    string[] replacements = new string[] { "a", "b", "c" };
    int i = 0;
    while (needle.IsMatch(haystack))
    {
        if (i >= replacements.Length)
        {
            break;
        }
        haystack = needle.Replace(haystack, replacements[i], 1);
        i++;
    }
