    List<string> lines = System.IO.File.ReadLines(fileName).ToList();
    List<string> output = new List<string>();
    foreach (string line in lines)
    {
        var words = 
            line.Split(new string[] { new string(' ', 5) },
                       StringSplitOptions.None).Select(input => input.Trim()).ToArray();
        Array.Resize(ref words, 8);
        words = words.Select(
                    input => string.IsNullOrEmpty(input) ? "  " : input).ToArray();
        output.Add(string.Join(new string(' ', 5), words));
    }
    //output:
    // 5     1     5     1     5      1     5      1       
    // 0     1     0     0     0      0     0      0
