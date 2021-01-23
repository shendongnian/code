    //'Removes the start part of the string, if it is matchs, otherwise leave string unchanged
        //NOTE:case-sensitive, if want case-incensitive, change ToLower both parameters before call
        public static string TrimStart(this string str, string sStartValue)
        {
            if (str.StartsWith(sStartValue))
            {
                str = str.Remove(0, sStartValue.Length);
            }
            return str;
        }
        //        'Removes the end part of the string, if it is matchs, otherwise leave string unchanged
        public static string TrimEnd(this string str, string sEndValue)
        {
            if (str.EndsWith(sEndValue))
            {
                str = str.Remove(str.Length - sEndValue.Length, sEndValue.Length);
            }
            return str;
        }
    //        'StripBrackets checks that starts from sStart and ends with sEnd (case sensitive).
    //        'If yes, than removes sStart and sEnd.
    //        'Otherwise returns full string unchanges
    //        'See also MidBetween
            public static string StripBrackets(this string str, string sStart, string sEnd)
            {
                if (StringHelper.CheckBrackets(str, sStart, sEnd))
                {
                    str = str.Substring(sStart.Length, (str.Length - sStart.Length) - sEnd.Length);
                }
                return str;
            }
