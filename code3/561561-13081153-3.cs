    using System.Reflection;
    public T GetStruct<T>() where T : struct
    {
        T myStruct = (T)Activator.CreateInstance<T>();
        FieldInfo[] infos = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);
        foreach (FieldInfo info in infos)
        { 
            //Do something to fill the values;
            info.SetValue(myStruct, myValue);
        }
        return myStruct;
    }
