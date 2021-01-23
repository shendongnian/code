    //initial string of 10000 entries divided by commas
    string s = string.Join(", ", Enumerable.Range(0, 10000));
    //an array of entries, from the original string
    var ss = s.Split(',');
    //auxiliary index
    int index = 0;
    //divide into groups by 1000 entries
    var words = ss.GroupBy(w =>
        {
            try
            {
                return index / 1000;
            }
            finally
            {
                ++index;
            }
        })//join groups into "words"
        .Select(g => string.Join(",", g));
    //print each word
    foreach (var word in words)
        Console.WriteLine(word);
