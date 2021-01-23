    var a = "ab,cd;ef,gh;ij,kl".ToTwoDimArray();
    public static class StringExtentions
    {
        public static string[][] ToTwoDimArray(this string source, char separatorOuter = ';', char separatorInner = ',')
        {
            return source
                   .Split(separatorOuter)
                   .Select(x => x.Split(separatorInner))
                   .ToArray();
        }
    }
