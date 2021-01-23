    public static class FormattingHelper
    {
        public static string GetFormatString(this string s)
        {
            if (s.Length == 12)
                return "{0:#### #### ## ####}";
            else
                return "{0:#### #### ## #### ##}";
        }
    }
    void Main()
    {
        var s1 = "23450000129999";
        var s2 = "234500001299";
        var d1 = decimal.Parse(s1);
        var d2 = decimal.Parse(s2);
    
        Console.Out.WriteLine(s1.GetFormatString(), d1);
        Console.Out.WriteLine(s2.GetFormatString(), d2);
    }
