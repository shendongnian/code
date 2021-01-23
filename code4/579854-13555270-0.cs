    var newstr = str.MySubString(start,end);
..
    public static partial class MyExtensions
    {
        public static string MySubString(this string s,int start,int end)
        {
            return s.Substring(start, end - start + 1);
        }
    }
