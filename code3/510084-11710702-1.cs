     Regex r = new Regex("&#[^;]+;");
     str = r.Replace(str, delegate(Match match)
     {
         string value = match.Value.ToString().Replace("&#", "").Replace(";", "");
         int asciiCode;
         if (int.TryParse(value, out asciiCode))
         {
             return Convert.ToChar(asciiCode).ToString();
         }
         else
         {
             return value;
         }                 
     });
