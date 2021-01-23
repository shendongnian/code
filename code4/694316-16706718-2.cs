    List<string> files = new List<string>();
    string[] hrefs = htmlText.Split(new string[]{"href=\""},                
         StringSplitOptions.RemoveEmptyEntries);
    foreach (string href in hrefs)
    {
         string[] possibleFile = href.Split(new string[]{"\""}, 
               StringSplitOptions.RemoveEmptyEntries);
         if (possibleFile.Length() > 0 && possibleFile[0].EndsWith(".exe"))
             files.Add(possibleFile[0]);
    }
