    public object[] GetValues(params Type types)
    {
        var result = new object[types.length];
        for (int i = 0; i < types.length; i++)
        {
            if(types[i] == typeof(string))
                result[i] = "foo";
            if(types[i] == typeof(int))
                result[i] = -1;
        }
        return result;
    }
    public void DoStuff()
    {
        var data = GetValues(typeof(string), typeof(int), typeof(string));
        string foo1 = (string)data[0];
        int someNumber = (int)data[1];
        string foo2 = (string)data[2];
    }
