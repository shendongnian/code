    /// <summary>
    /// Does a nice trim for your string
    /// </summary>
    /// <param name="Subject">The subject</param>
    /// <param name="Search">What to trim on the string</param>
    /// <param name="TrimEnd">If set to true we trim the end</param>
    /// <returns></returns>
    public static string TrimEndOrStart(string Subject, string Search, bool TrimEnd)
    {
        if (TrimEnd)
        {
            if (Subject.EndsWith(Search) == false)
            {
                return Subject;
            }
            Subject = StaticMethods.ReverseString(Subject);
            Start:
                string[] Array1 = Subject.Split(new string[] {       StaticMethods.ReverseString(Search) }, 2, StringSplitOptions.RemoveEmptyEntries);
            
            if (Array1.Length == 1)
            {
                if (Subject.Equals(Array1[0], StringComparison.Ordinal) == false)
                {
                    Subject = Array1[0];
                    goto Start;
                }
            }
            Subject = StaticMethods.ReverseString(Subject);
            return Subject;
        }
        if (Subject.StartsWith(Search) == false)
        {
            return Subject;
        }
        Start2:
            string[] Array2 = Subject.Split(new string[] { Search }, 2,  StringSplitOptions.RemoveEmptyEntries);
        
        if (Subject.Equals(Array2[0], StringComparison.Ordinal) == false)
        {
            Subject = Array2[0];
            goto Start2;
        }
        return Subject;
    }
    /// <summary>
    /// Reverses a string array
    /// </summary>
    /// <param name="StrArray"></param>
    /// <returns></returns>
    public static string ReverseString(string Str)
    {
        char[] ObjectArr = Str.ToCharArray();
        char[] NewObjectArr = new char[ObjectArr.Length];
        int counter = 0;
        for (int index = ObjectArr.Length - 1; index > -1; index--)
        {
            NewObjectArr[counter] = ObjectArr[index];
            counter = counter + 1;
        }
        Str = "";
        StringBuilder StrBu = new StringBuilder(1000);
        
        for (int index = 0; index < NewObjectArr.Length; index++)
        {
            StrBu.Append(NewObjectArr[index]);
        }
        Str = StrBu.ToString();
        return Str;
    }
