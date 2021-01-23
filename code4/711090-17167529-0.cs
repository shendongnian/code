    var emails = File.ReadAllLines(@"foo.txt")
                           .Where(x => x.IsValidEmailAddress());
    public static class extensionMethods
        {
            public static bool IsValidEmailAddress(this string s)
            {
                Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                return regex.IsMatch(s);
            }
        }
