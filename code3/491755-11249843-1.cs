    public void ConsolidateDictionary(string directoryPath)
    {
       DirectoryInfo directory = new DirectoryInfo(directoryPath);
       string key = string.Empty;
       string value = string.Empty;
       Dictionary<string, List<string>> languages = new Dictionary<string, List<string>>();
       List<string> temp = null;
       foreach (FileInfo file in directory.EnumerateFiles())
       {
           HtmlDocument doc = new HtmlDocument();
           doc.Load(file.FullName);
    
           foreach (HtmlNode node in doc.DocumentNode.SelectNodes(".//wordunit"))
           {
              foreach (HtmlNode child in node.SelectNodes(".//word"))
               {
                       if (child.Attributes["language"].Value == "EN")
                       {
                           key = child.OuterHtml.ToString();
                       }
                       else
                       {
                           value = child.OuterHtml.ToString();
                       }
               }
    
               if (key != null && value != null)
               {
                   if (languages.ContainsKey(key))
                   {
    				if(languages[key].Items.Contains(value) == false)
    				         languages[key].Add(value);
                   }
                   else
                   {
    					languages.Add(key, new List<string>);
    					languages[key].Add(value);
                   }
               }
           }
       }
       WriteFile(languages);
     }
