    List<Address> result = new List<Address>();
    foreach (string str in strings)
    {
        Address addr = new Address();
        result.Add(addr);
        int num, numIndex = int.MinValue;
        string[] tokens = str.Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < tokens.Length; i++)
        {
            if (!addr.Number.HasValue && int.TryParse(tokens[i], out num))
            {
                addr.Number = num;
                numIndex = i;
            }
        }
        if (addr.Number.HasValue)
        {
            addr.Street = string.Join(" ", tokens.Where((s, i) => i != numIndex));
        }
        else
        {
            addr.Street = str;
        }
    }
