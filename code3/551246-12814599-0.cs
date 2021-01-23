    if(searchField == "ID")
    {
       testList = testList.Where(x => x.ID == searchString);
    }
    else if (searchField == "Name")
    {
       testList = testList.Where(x => x.Name.Contains(searchString);
    }
    else if (searchField == "Nationality")
    {
       testList = testList.Where(x => x.Nationality.Contains(searchString);
    }
    
   
