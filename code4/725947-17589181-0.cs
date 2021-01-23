     List<String> txtlist = Directory.GetFiles(directorypath, "*.txt").ToList();
     List<String> xmllist = Directory.GetFiles(directorypath, "*.xml").Select(f => Path.GetFileName(f)).ToList();
     foreach (var txt in txtlist)
     {
         StreamReader file = new StreamReader(txt);
         while ((line = file.ReadLine()) != null)
         {
             foreach (var xml in xmlist)
             {
                 if (xml == line)
                 {
                 break;
                 }
             }
        }
     }
