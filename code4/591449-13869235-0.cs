    string date = "10/25/2011";
    string[] sep = new string[]{"/","-", " "}; --All possible format characters.
    char[] c = date.ToCharArray();
    string[] arr = c.Select(ch => ch.ToString())
                               .Where(s => !sep.Contains(s)).ToArray(); --only numbers 
    string formattedDate = 
       string.Format(arr.Length == 6 ? 
       "20{4}{5}-{0}{1}-{2}{3}T00:00:00" : "{4}{5}{6}{7}-{0}{1}-{2}{3}T00:00:00", arr);
    
    DateTime mydate = Convert.ToDateTime(formattedDate);
