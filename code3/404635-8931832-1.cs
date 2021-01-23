     public static string ToEnglishName(this char c)
     {
        int i = (int)c;
        if( i < lookup.Length )
           return lookup[i];
        return "Unknown";
     }
     
     var name = ':'.ToEnglishName(); // Colon
