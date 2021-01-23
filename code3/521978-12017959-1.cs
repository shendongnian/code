    var list = input.Split(new[] { "==", "!=", "&&", "||" }, 
                StringSplitOptions.RemoveEmptyEntries);
    var result = Enumerable.Range(0, list.Length/2)
                .Select(i => list.ElementAt(i*2).Trim())
                .Select(s => s.Substring(1, s.Length - 2));
