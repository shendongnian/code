    public static string MyMethod(string s, int i, DateTime d)
    {
        return s + " " + i + " " + d.ToString();
    }
    public T Execute<T>()
    {
        //They are all strings in object array
        object[] myparams = new object[] {"test","3","04/03/2012" };
  
        Type[] types = this.GetType()
                           .GetMethod("MyMethod")
                           .GetParameters()
                           .Select(p=>p.ParameterType)
                           .ToArray();
        object result = 
            this.GetType().InvokeMember(
            "MyMethod",
            BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static,
            null,
            this,
            myparams.Select((s,i)=>Convert.ChangeType(s,types[i])).ToArray()
            );
        return (T)result;
    }
