        Dictionary<int, List<string>> fileList = new Dictionary<int, List<string>>();
        fileList.Add(101, new List<string> { "fijo", "Frigy" });
        fileList.Add(102, new List<string> { "lijo", "liji" });
       fileList.Add(103, new List<string> { "vimal", "vilma" });
         for (int Key = 101; Key < 104; Key++)
         {
               for (int ListIndex = 0; ListIndex < fileList[Key].Count; ListIndex++)
              {
                   Console.WriteLine(fileList[Key][ListIndex] as string);
               }
            }
        
