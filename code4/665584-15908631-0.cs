    public static void Log(string Data = null, string Type = null, string URL = null, StringBuilder Parameters = null)
    {
        string Output = "";
        if (Data != null)
        {
            Output = "Response: " + Data;
        }
        else if (Type != null && URL != null && Parameters != null)
        {
            Output = Type + ":" + new string(' ', 9 - Type.Length) + URL + " { " + Parameters.ToString() + " }";
        }
        else
        {
            throw new ArgumentException("Provide yada yada arguments lala");
        }
        Trace.WriteLine(Output);
        if (OutputToConsole) Console.WriteLine(Output);
    }
