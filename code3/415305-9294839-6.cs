    /// <summary>
    /// Appends the string returned by processing a composite format string followed by the default line terminator.
    /// </summary>
    /// <param name="sb">The StringBuilder.</param>
    /// <param name="format">The format.</param>
    /// <param name="args">The args.</param>
    public static void AppendLineFormat(this StringBuilder sb, string format, params object[] args)
    {
        sb.AppendFormat(format, args);
        sb.AppendLine();
    }
