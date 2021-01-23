    MatchCollection mcol = System.Text.RegularExpression.Regex.Matches(foo,"(\d+)(?=%)");
    
    foreach (Match m in mcol)
    {
       System.Diagnostic.Debug.Print(m.ToString());
    }
