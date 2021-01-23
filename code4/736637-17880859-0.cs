    var reader = new StreamReader(File.OpenRead(@"C:\test.csv"));
    List<string> listA = new List<string>();
                
    while (!reader.EndOfStream)
    {
                    
     var line = reader.ReadLine();
    
    string[] dates = line.Split(',');           
    for (int i = 0; i < dates.Length; i++)
      {
      if(i==0)
      listA.Add(dates[0]);
      }
                    
                    
     }
