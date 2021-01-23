    public IEnumerable<Tuple<string,char>> MagicSplit(string input, char[] split)
    {    
        var buffer = new StringBuilder();
        foreach (var c in input)
        {
            if (split.Contains(c)) 
            {
                var result = buffer.ToString();
                buffer.Clear();
                yield return Tuple.Create(result,c);
            }
            else
            {
                buffer.Append(c);
            }
        }
    }
