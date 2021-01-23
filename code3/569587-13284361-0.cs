    var matches = {"string1", "string2", "string3","string-n"};
    var i = 0;
    foreach(string s in matches)
    {
        if(mystring.Contains(s))
        {
            i++;
        }
    }
    if(i == matches.Length)
    {
        //string contains all matches.
    }
