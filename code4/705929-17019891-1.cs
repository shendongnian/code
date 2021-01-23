    public static String ReadToEndAndClose(this StreamReader stream)
    {
        using(var sr = stream)
        {
            return sr.ReadToEnd();
        }
    }
