    string tessst = "abra[s{p(a)c}e]kada[s{p(a)c}e]bra[n|e|w)hel[s{p(a)c}e]oww[s{p(a)c}e]een";
    List<string[]> splited2 = new List<string[]>();
    if (tessst.Length > 0)
    {
        List<string> splited1 = new List<string>(Regex.Split(tessst, @"\[n\|e\|w\)")); 
        for (int i = 0; i < splited1.Count; i++)
        {
            splited2.Add(Regex.Split(splited1[i], @"\[s\{p\(a\)c\}e\]"));
        }
    }
