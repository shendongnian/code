    XDocument doc = XDocument.Load("file.xml");
    var serviceNodes = doc.Descendants("service");
    
    Dictionary<string, int> dict = new Dictionary<string,int>();
    
    foreach(string name in serviceNodes.Element("Name"))
    {
         if(dict.ContainsKey(name))
         {
            dict[name]++;
         }
         else
         {
            dict[name]=1;
         }
    }
    foreach(int item in dict)
    {
       Console.WriteLine("{0}={1}",item.Key,item.Value);
    }
