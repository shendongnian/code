    static void Main()
    {
        Prepare(typeof(A), typeof(B), typeof(C));
        // if you really want to use IFormatter...
        var formatter = RuntimeTypeModel.Default.CreateFormatter(typeof (A));
        var obj = new A {Bs = new B[] {new B()}};
        using (var ms = new MemoryStream())
        {
            formatter.Serialize(ms, obj);
            ms.Position = 0;
            var clone = formatter.Deserialize(ms);
        }
    }
    static void Prepare(params Type[] types)
    {
        if(types != null) foreach(var type in types) Prepare(type);
    }
    static void Prepare(Type type)
    {
        if(type != null && !RuntimeTypeModel.Default.IsDefined(type))
        {
            Debug.WriteLine("Preparing: " + type.FullName);
            // note this has no defined sort, so invent one
            var props = type.GetProperties(); 
            Array.Sort(props, (x, y) => string.Compare(
                x.Name, y.Name, StringComparison.Ordinal));
            var meta = RuntimeTypeModel.Default.Add(type, false);
            int fieldNum = 1;
            for(int i = 0 ; i < props.Length ; i++)
            {
                meta.Add(fieldNum++, props[i].Name);
            }
           
        }
    }
