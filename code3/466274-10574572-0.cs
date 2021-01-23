    T t;
    var typeInfo = typeof(T);
    var method = typeInfo.GetMethod("TryParse", BindingFlags.Public | BindingFlags.Static);
    var result = (bool)method.Invoke(null, new object[] { str, t });
    if (result)
        return t;
