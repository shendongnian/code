    Dictionary<char,int> counts = new Dictionary<char,int>();
    
    foreach (char c in myCharArray)
    {
    if (counts.Keys.Contains(c))
    {
    counts[c]++;
    myOutputList.Add(c + "(" + counts[c] + ")");
    }
    else 
    {
    counts.Add(c,0);
    }
