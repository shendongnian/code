    public static T Cast<T>(this XElement x, string name) where T : struct
    {
        XElement e = x.Element(name);
        if (e == null)
            return default(T);
        else
        {
            Type t = typeof(T);
            MethodInfo mi = t.GetMethod("TryParse",
                                        BindingFlags.Public | BindingFlags.Static,
                                        Type.DefaultBinder,
                                        new Type[] { typeof(string), 
                                                     t.MakeByRefType() },
                                        null);
            var paramList = new object[] { e.Value, null };
            mi.Invoke(null, paramList);
            return (T)paramList[1]; //returns default(T), if couldn't parse
        }
    }
