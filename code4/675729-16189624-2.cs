    var temp = 
        listStructure.Descendants("Field")
                     .Where(i => i.Attribute("DisplayName").Value == "Area")
                                 .Select(i => i.Descendants("CHOICE") 
                                              .Select(j => j.Value)).ToList();
    List<string> result = new List<string>();
    foreach (IEnumerable<string> item in temp)
    {
        result.AddRange(item);
    }
    //result: Articles; Websites; Books
