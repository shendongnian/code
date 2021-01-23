       public bool IsValidEmail(string strIn)
       {
           invalid = false;
           if (String.IsNullOrEmpty(strIn))
              return false;
    
           // Use IdnMapping class to convert Unicode domain names. 
           try {
              strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                    RegexOptions.None, TimeSpan.FromMilliseconds(200));
           }
           catch (RegexMatchTimeoutException) {
             return false;
           }
    
           if (invalid) 
              return false;
    
           // Return true if strIn is in valid e-mail format. 
           try {
              return Regex.IsMatch(strIn, 
                    @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + 
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$", 
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
           }  
           catch (RegexMatchTimeoutException) {
              return false;
           }
       }
