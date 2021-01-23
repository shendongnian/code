    public static string Ellipsis(this string str, int TotalWidth, string Ellipsis = "...")     
    {
        string output = "";
        if (!string.IsNullOrWhiteSpace(str) && str.Length > TotalWidth)
        {
            output = output.Left(TotalWidth) + Ellipsis;
        }
        return output;
    }
