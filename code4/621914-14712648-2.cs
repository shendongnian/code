    var methodInfo = typeof(T).GetMethod("IsValid", BindingFlags.Static|BindingFlags.Public);
    if (methodInfo != null)
    {
        object[] parameters = new object[] { genericStructItem, null };
        if ((bool)methodInfo.Invoke(null, parameters))
        {
            // It's valid!
        }
        else
        {
            string error = (string)parameters[1];
        }
    }
