    public static char ReadKey(IEnumerable<char> validKeys)
    {
        var validKeySet = new HashSet<char>(validKeys);
        while (true)
        {
            var key = Console.ReadKey(true);
            if (validKeySet.Contains(key.KeyChar))
            {
                //you could print it out if you wanted.
                //Console.Write(key.KeyChar);
                return key.KeyChar;
            }
            else
            {
                //you could print an error message here if you wanted.
            }
        }
    }
