    List<Info> tempList;
    Info tempInfo;
    foreach(var line in listName)
    {
      if(string.IsNullOrWhiteSpace(line))
        continue;
      tempInfo = new Info(line);
      foreach(var author in info.Authors)
      {
        if(!infoByAuthor.TryGetValue(author, out tempList))
          tempInfo[author] = tempList = new List<Info>();
        tempList.Add(tempInfo);
      }
    }
