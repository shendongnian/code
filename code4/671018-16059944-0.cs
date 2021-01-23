     string str="The.Big.Bang.Theory.(2013).S07E05.Release.mp4";
     var  matches = Regex.Matches(str, @"\([0-9]{4}\)");
     List<string> removed=new List<string>();
     if (matches.Count > 0)
      {
        for (int i = 0; i < matches.Count; i++)
        {
          List.add(matches.value);
        }
      }  
     str=Regex.replace(str,@"\([0-9]{4}\)","___");
      
    System.out.println("Removed Strings are:")
    foreach(string s in removed )
    {
        System.out.println(s);
    }
    
   
