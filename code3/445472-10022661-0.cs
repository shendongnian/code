    static void Check(object o)
    {
      Console.WriteLine("Type {0} converted to Int64: {1}",
        o.GetType().Name,
        o is ulong ? (long)(ulong)o : Convert.ToInt64(o));
    }
    static void CheckU(object o)
    {
      Console.WriteLine("Type {0} converted to UInt64: {1}",
        o.GetType().Name,
        o is ulong ? (ulong)o : (ulong)Convert.ToInt64(o));
    }
