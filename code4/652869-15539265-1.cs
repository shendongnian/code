    List<string> imageFiles= ... // Here you get the image path
    Dictionary<int, List<string>> groupedPaths= ... //output dict
    foreach(string str in imageFiles)
    {
        FileInfo fi=new FileInfo(str);
        int year = fi.CreationTime.Year;
        if(!groupedPath.HasKey(year))
        {
           var list=new List<string>();
           list.Add(year, string);
           groupedPaths.Add(year, list);
        }
       else
       {   
           groupedPaths[year].Add(year, str);
       }
    //Now you can use LINQ to group your images
  
 
