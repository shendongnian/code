    public string EscapeXMLValue(string value)
      {
        if (string.IsNullOrEmpty(s)) return s;
       string temp = s;
       temp = temp.Replace("'","&apos;").Replace( "\"", "&quot;").Replace(">","&gt;").Replace( "<","&lt;").Replace( "&","&amp;");
       return temp ;
     }
