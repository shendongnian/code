    List<string> results = new List<string>();
    int curInd = 0;
    var matchInfo = Regex.Matches(number, "(0|1)");
    foreach (Match m in matchInfo)
    {
        //Currently at the start of a match, add the match sequence to the result list.
        if (curInd == m.Index)
        {
            results.Add(number.Substring(m.Index, m.Length));
            curInd += m.Length;  
        }
        else  //add the substring up to the match point and then add the match itself
        {
            results.Add(number.Substring(curInd, m.Index - curInd));
            results.Add(number.Substring(m.Index, m.Length));
            curInd = m.Index + m.Length;
        }
    }
    //add any remaining text after the last match
    if (curInd < number.Length)
    {
        results.Add(number.Substring(curInd));
    }
