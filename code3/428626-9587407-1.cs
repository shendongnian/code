    public class Url
    {
        public static string GetUrlFriendlyName(string name)
        {
            //Unwanted:  {UPPERCASE} ; / ? : @ & = + $ , . ! ~ * ' ( )
            name = name.ToLower();
            //Strip any unwanted characters
            name = Regex.Replace(name, @"[^a-z0-9_\s-]", "");
            //Clean multiple dashes or whitespaces
            name = Regex.Replace(name, @"[\s-]+", " ");
            //Convert whitespaces and underscore to dash
            name = Regex.Replace(name, @"[\s_]", "-");
            name = Regex.Replace(name, @"-+", "-");
            return name;
        }
    }
