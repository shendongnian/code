    string date = "10/25/2011";
    string[] arr = date.ToArray() 
                  .Where(ch => ch > 47 && ch < 58 ) //Filter out all but numbers
                  .Select(s => s.ToString()).ToArray(); 
    
    if(arr.Length >5)
    {
       string ISOformattedDate = string.Format( arr.Length == 6 ? 
              "{4}{5}-{0}{1}-{2}{3}T00:00:00" : 
              "{4}{5}{6}{7}-{0}{1}-{2}{3}T00:00:00", arr);
       DateTime mydate = Convert.ToDateTime(ISOformattedDate);
    {
