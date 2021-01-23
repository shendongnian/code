    public static string ParseText(string text, string preferedValue=null)
    {
            return Regex.Replace(text, regex, match =>
            {
                string varName = match.Groups[1].Value;
    
                if (variables.ContainsKey(varName))
                {
                    if(!string.IsNullOrEmpty(preferedValue)) //IF THERE ISPREFERED VALUE                                                         
                           return preferedValue;             //RETURN THAT ONE
    
                    return variables[varName].ToString();
                }
                else
                    return match.Value;
            });
    }
