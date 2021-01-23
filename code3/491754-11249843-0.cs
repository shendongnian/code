    1 public void ConsolidateDictionary(string directoryPath)
    2 {
    3    DirectoryInfo directory = new DirectoryInfo(directoryPath);
    4    string key = string.Empty;
    5    string value = string.Empty;
    6    Dictionary<string, List<string>> languages = new Dictionary<string, List<string>>();
    7    List<string> temp = null;
    8    foreach (FileInfo file in directory.EnumerateFiles())
    9    {
    10       HtmlDocument doc = new HtmlDocument();
    11       doc.Load(file.FullName);
    12
    13       foreach (HtmlNode node in doc.DocumentNode.SelectNodes(".//wordunit"))
    14       {
    15          foreach (HtmlNode child in node.SelectNodes(".//word"))
    16           {
    17                   if (child.Attributes["language"].Value == "EN")
    18                   {
    19                       key = child.OuterHtml.ToString();
    20                   }
    21                   else
    22                   {
    23                       value = child.OuterHtml.ToString();
    24                   }
    25           }
    26
    27           if (key != null && value != null)
    28           {
                     // new line
                     temp = new List<string>();
    29               if (languages.ContainsKey(key))
    30               {
    31                   foreach (var item in languages[key])
    32                   {
    33                       temp.Add(item);
    34                   }
    35                   temp.Add(value);
    36                   languages.Remove(key);
    37                   languages.Add(key, temp);
    39               }
    40               else
    41               {
    42                       temp.Add(value);
    43                       languages.Add(key, temp);
    45               }
    46           }
    47       }
    48   }
    49   WriteFile(languages);
    50 }
