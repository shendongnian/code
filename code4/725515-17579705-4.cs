    string msg= "=?windows-1258?B?UkU6IFRyIDogUGxhbiBkZSBjb250aW51aXTpIGQnYWN0aXZpdOkgZGVz?= =?windows-1258?B?IHNlcnZldXJzIFdlYiBHb1ZveWFnZXN=?=";
    var charSetOccurences = new Regex(@"=\?.*?(\?[A-Z]\?).*?\?=", RegexOptions.IgnoreCase);
    MatchCollection matches = charSetOccurences.Matches(msg);
    foreach (Match match in matches)
    {
        string[] encoding = match.Groups[0].Value.Split(new string[]{ "?" }, StringSplitOptions.None);
        string charSet = encoding[1];
        string encodeType = encoding[2];
        string encodedString = encoding[3];
        Console.WriteLine("Charset: " + charSet);
        Console.WriteLine("Encoding type: " + encodeType);
        Console.WriteLine("Encoded String: " + encodedString + "\n");
    }
