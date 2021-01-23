    static void Main(string[] args)
    {
        var maybe = new ArrayList(3);
        maybe.Add(100f);
        maybe.Add("not a number");
        maybe.Add(1000);
        foreach (var item in maybe)
        {
            Console.WriteLine(item);
        }
        ArrayList res = new ArrayList(maybe.ToArray().Where((o) => o.IsNumber()).ToArray());
        foreach (var item in res)
        {
            Console.WriteLine(item);
        }
    }
    public static bool IsNumber(this object item)
    {
        const TypeCode filter = TypeCode.Double | TypeCode.Int16 | TypeCode.Int32 | TypeCode.Int64
            | TypeCode.Single | TypeCode.UInt16 | TypeCode.UInt32 | TypeCode.UInt64;
        Type t = item.GetType();
        if (t.IsPrimitive)
        {                
            TypeCode code = System.Type.GetTypeCode(t);
            return (code & filter) > 0;
        }
        return false;
    }
