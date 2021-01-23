    string sPattern = "[a-zA-Z 0-9]*([a-zA-Z]),.*";
    int i = 0;
    foreach (string s in address)
    {
         Match m = Regex.Match(s, sPattern);
         if (m.Success){
             houseLetter[i] = m.ToString(); 
         } else {
             houseLetter[i] = "Not Found";
         }
         i++;
    }
