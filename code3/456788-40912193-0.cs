    public string RemoveAttributes(string value){
       var attributeClean = new System.Text.RegularExpressions.Regex(@"\<[a-z]+\b(.+?)\s?\\?\>", System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);
       while (attributeClean.IsMatch(value)) {
          var match = attributeClean.Match(value);
          value = value.Remove(match.Index, match.Length);
       }
       return value;
    }
