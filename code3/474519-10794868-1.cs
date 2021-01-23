    ArrayList list = new ArrayList();
    //Insert to list few objects
    ArrayList specificList = new ArrayList(); 
    for (int i = 0; i < list.Count ; i++)
    {
        if (list[i].Name.Contains("ogrod87"))
            specificList.Add(list[i]);
    }
