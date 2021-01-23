    List<string> modifiedList = new List<string>();
    
    foreach (string line in lines.Where(l => l.Length >= 5))
    {
         string ad = line.Remove(0, 11);
    
         if ((ad.Contains(mobName) && ad.Contains("dies")))
         {
            mobDeathCount++;
         }
         if (ad.Contains(mobName) && ad.Contains("drops"))
         {
             string lastpart = ad.Substring(ad.LastIndexOf("drops"));
             string modifiedLastpart = lastpart.Remove(0, 6);
             modifiedList.Add(modifiedLastpart);
         }
    
    }
    
    
    var lineCountDict = modifiedList.GroupBy(x => x).Where(x => x.Count() > 1).ToDictionary(x => x.Key, x => x.Count());
    foreach (var val in lineCountDict)
    {
       Console.WriteLine(val.Key + " - " + val.Value);
    }
