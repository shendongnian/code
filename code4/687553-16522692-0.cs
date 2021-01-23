    // creation
    var marqueeList = new List<MarqueControl.Entity.TextElement>();
    
    for (int i = 1; i<=3; i++)
    {
      marqueeList.Add(new MarqueControl.Entity.TextElement("TextElement "+i));
    }
    
    // usage
    for(int i=0;i<dt.Rows.Count ;i++)
    {
      String wholetext = [here is your retrieving code];
      marqueeList[0] = new MarqueControl.Entity.TextElement(wholetext); // 0 = first item
      // OR:
      marqueeList[i] = new MarqueControl.Entity.TextElement(wholetext);
    }
