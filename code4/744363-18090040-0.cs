    string GetRealFormat(string format, DateTimeFormatInfo dtfi)
    {
        MethodInfo method = Type.GetType("System.DateTimeFormat")
            .GetMethod("GetRealFormat", 
                       BindingFlags.Static | BindingFlags.NonPublic);
        return method.Invoke(null, new object[] { format, dtfi }) as string;
    }
