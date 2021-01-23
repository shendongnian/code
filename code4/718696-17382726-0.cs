    foreach (string candidate in keys)
    {
        string value;
        if (items.TryGetValue(candidate, out value))
        {
            Console.WriteLine("Key {0} had value {1}", candidate, value);
        }
        else
        {
            Console.WriteLine("No value for key {0}", candidate);
        }
    }
