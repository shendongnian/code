    var finalstr = System.IO.SearchOption.TopDirectoryOnly.GetString();
    public static class MyExtensions
    {
        public static string GetString(this Enum en)
        {
            return Regex.Replace(en.ToString(), "(?<=[a-z])(?<x>[A-Z])|(?<=.)(?<x>[A-Z])(?=[a-z])|(?<=[^0-9])(?<x>[0-9])(?=.)", me => " " + me.Value.ToLower());
        }
    }
