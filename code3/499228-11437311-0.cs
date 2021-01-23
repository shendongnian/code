    public static string GetResultsWithHyphen(string str) {
      return Regex.Replace(str, "(.{4})", "$1-");
    }
        
    public static string GetResultsWithOutHyphen(string str) {            
      //if you just want to remove the hyphens:
      //return input.Replace("-", "");
      //if you REALLY want to remove hyphens only if they occur after 4 places:
       return Regex.Replace(str, "(.{4})-", "$1");
    }
