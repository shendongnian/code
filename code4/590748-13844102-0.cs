    string numbers = "12.34.56.78";
    var parts = String.Split(new char [] {'.'});
    string newNumbers = String.Join("",parts.Take(parts.Length-1)
                                            .Concat(".")
                                            .Concat(parts.Last());
