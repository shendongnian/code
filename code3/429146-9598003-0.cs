    string input = "/C001/dsafalkdsfjsadfj";
    var pattern = @"/C[A-Z0-9]{3}/.*";
    var matches = Regex.Matches(input, pattern);
    string result = "";
    for (int i = 0; i < matches.Count; i++)
    {
    	result += "match " + i + ",value:" + matches[i].Value + "\n";
    }
    Console.WriteLine("Result:\n"+result);
