    var Alphabet = "abcdefghijklmnopqrstuvwxyz".ToArray();
    var Pairs = new Dictionary<char, string>();
    for(var i = 1; i < Alphabet.Count() +1; i++)
    	Pairs.Add(Alphabet[i-1], "090" + (i < 10 ? "0" + i.ToString() : i.ToString()));
    	
    var Source = "14534000000875";
    
    var Chars = Source.Where(x => Char.IsLetter(x));
    var Output = string.Empty();
    foreach(var Char in Chars)
    	Output = Source.Replace(Char.ToString(), Pairs[Char]);
