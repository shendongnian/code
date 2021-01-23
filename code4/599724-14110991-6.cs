    List<Address> addresses = new List<Address>();
    foreach (string str in strings)
    {
        Address addr = new Address();
        addresses.Add(addr);
        int num, numIndex = int.MinValue;
        string[] tokens = str.Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < tokens.Length; i++)
        {
            if (int.TryParse(tokens[i], out num))
            {
                addr.Number = num;
                numIndex = i;
                break;
            }
        }
        if (addr.Number.HasValue)
        {
            // join the rest with white-spaces to the street name skipping the number
            addr.Street = string.Join(" ", tokens.Where((s, i) => i != numIndex));
        }
        else
        {
            addr.Street = str;
        }
    }
