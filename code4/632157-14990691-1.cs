    bool TryCheckHeaderName(string name)
    {
       if (string.IsNullOrEmpty(name))
       {
           return false;
       }
       if (HttpRuleParser.GetTokenLength(name, 0) != name.Length)
       {
           return false;
       }
       if ((this.invalidHeaders != null) && this.invalidHeaders.Contains(name))
       {
           return false;
       }
       return true;
    }
