    //Declaration. This will map a Url to one or more keywords.
    Dictionary<string, List<string>> LocalyKeyWords = new Dictionary<string, List<string>>();
    ...
    //Adding an item.
    if(LocalyKeyWords.ContainsKey(mainUrl)
    {
        LocalyKeyWords[mainUrl].Add(crawlLocaly1.getText());
    }
    else
    {
        LocalyKeyWords.Add(mainUrl, new List<string>(new string[] { crawlLocaly1.getText() } ));
    }
    ...
    private void removeExternals(List<string> externals)    
    {    
         if(!LocalyKeyWords.ContainsKey(mainUrl))
         {
             return;
         }
         List<string> keywords = LocalyKeyWords[mainUrl];
         List<int> indices = new List<int>();
         foreach(string keyword in keywords)
         {
             //Accumulate a list of the indices of the items that match.
             indices = indices.Concat(externals.Select((v, i)
                 => v.Contains(keyword) ? i : -1 )).ToList();         
         }
         //Filter out the -1s, grab only the unique indices.
         indices = indices.Where(i => i >= 0).Distinct().ToList();
         //Filter out those items that match the keyword(s) related to mainUrl.
         externals = externals.Where((v, i) => !indices.Contains(i)).ToList();    
    } 
