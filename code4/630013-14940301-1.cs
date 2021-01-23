    public static class SqlReservedKeywords {
       public bool isReserved(string in)
       {
          return SqlServerKeywords.Contains(in.ToUpper());
       }
       private static HashSet<string> SqlServerKeywords = new HashSet<string>();
       SqlReservedKeywords() 
       {
          SqlServerKeywords.Add("ADD");
          SqlServerKeywords.Add("EXISTS");
          SqlServerKeywords.Add("PRECISION");
       //. . .
          SqlServerKeywords.Add("EXEC");
          SqlServerKeywords.Add("PIVOT");
          SqlServerKeywords.Add("WITH");
          SqlServerKeywords.Add("EXECUTE");
          SqlServerKeywords.Add("PLAN");
          SqlServerKeywords.Add("WRITETEXT");
       }   
    }
