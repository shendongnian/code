    string searchString = "123,12346";
    bool b = sep(searchString,",").Contains("1234");
    //Returns this string before ","
    public static string sep(string s,string delimiter)
    {
       int indx = s.IndexOf(delimiter);
       if (indx >0)
       {
          return s.Substring(0, indx);
       }
       return "";
    }
    
