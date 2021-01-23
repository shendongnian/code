    public static string GetStringBetween(this string token, string first, string second)
        {            
            if (!token.Contains(first)) return "";
            var afterFirst = token.Split(new[] { first }, StringSplitOptions.None)[1];
            if (!afterFirst.Contains(second)) return "";
            var result = afterFirst.Split(new[] { second }, StringSplitOptions.None)[0];
            return result;
        }
