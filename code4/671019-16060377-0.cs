    string pattern = @"\((19|20)\d{2}\)";
    string search = "The.Big.Bang.Theory.(2013).S07E05.Release.mp4";
    string replaced = Regex.Match(search, pattern).Captures[0].ToString();
    string output = Regex.Replace(search, pattern, "___");
    Console.WriteLine("found: {0}  output: {1}",replaced,output);
