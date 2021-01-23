    /// <summary>
    /// Convert the guid to a quoted string
    /// </summary>
    /// <param name="source">A Guid to convert to a quoted string</param>
    /// <returns></returns>
    public static string ToQuotedStr(this Guid source)
    {
       String s = "'" + source.ToString("B") + "'"; //B=braces format "{6CC82DE0-F45D-4ED1-8FAB-5C23DE0FF64C}"
	
       //Record how often we dealt with each type of UUID
       Sqm.Increment("String.ToQuotedStr_UUIDType_"+s[16], 1);
       return s;
    }
