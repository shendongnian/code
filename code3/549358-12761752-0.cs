     private static Regex oClearHtmlScript = new Regex(@"<(.|\n)*?>", RegexOptions.Compiled);
    
     public static string StripHTML(string sHtmlKeimeo)
     {
         if (string.IsNullOrEmpty(sHtmlKeimeo))
             return string.Empty;   
    
         return oClearHtmlScript.Replace(sHtmlKeimeo, string.Empty);
     }
