    static void Main(string[] args)
    {
        Receive(1, true);
    }
    
    static void Receive(params object[] values)
    {
        foreach (var v in values)
        {
            if (v is int)
            {
                // ...
            }
            else if (v is bool)
            {
                // ...
            }
        }
    }
