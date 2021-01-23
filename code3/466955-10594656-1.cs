    List<Info> tempList;
    Info tempInfo;
    foreach(var line in listName)
    {
      tempInfo = new Info(line);
      if(!infoByAuthor.TryGetValue(tempInfo.AuthorName, out tempList))
        tempInfo[info.AuthorName] = tempList = new List<Info>();
      tempList.Add(tempInfo);
    }
