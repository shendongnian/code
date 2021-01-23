    var newstr = "a string".SpaceToUnderScore();
    public static class SomeExtensions
    {
        public static string SpaceToUnderScore(this string source)
        {
            return new string(source.Select(c => char.IsWhiteSpace(c) ? '_' : c).ToArray());
            //or
            //return String.Join("",source.Select(c => char.IsWhiteSpace(c) ? '_' : c));
        }
    }
