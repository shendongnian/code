    public bool IsAlpha(string strToCheck)
      {
        Regex objAlphaPattern=new Regex("[^a-zA-Z]");
    
        return !objAlphaPattern.IsMatch(strToCheck);
      }
    Regards
