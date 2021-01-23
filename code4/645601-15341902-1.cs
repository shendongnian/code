    public static void WriteLineToResponse(string format, params object[] args)
    {
        Response.Write(String.Format(format, args));
        Response.Write(Environment.NewLine);
    }
