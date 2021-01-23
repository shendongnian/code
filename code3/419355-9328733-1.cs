    int findID = 3;
    int foundID=  -1;
    for (int i = 0; i< PLUList.Count; i++)
    {
      if (PLUList[i].ID == findID)
      {
        foundID = i;
        break;
      }
    }
    
    // Your code.
    if (foundID > -1) {
    // Do something here
    ...
