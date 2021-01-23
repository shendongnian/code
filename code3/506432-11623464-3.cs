    private static string DoFormat(string data, string format, object[] parameters)
    {
        Type[] parameterTypes = (from p in parameters select p.GetType()).ToArray();
        MethodInfo mi = typeof(string).GetMethod(format, parameterTypes);
        if (null == mi)
            throw new Exception(String.Format("Could not find method with name '{0}'", format));
        return mi.Invoke(data, parameters).ToString();
    }
