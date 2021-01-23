    class Lazy
    {
       public static string FirstLetterToUpper(string str)
       {
           return Char.ToUpper(str[0]) + str.Substring(1);
       }
    }
