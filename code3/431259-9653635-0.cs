    listA = listA.OrderBy(x=>x.ID).ToList();
    myList = myList.OrderBy(x=>x.ID).ToList(); 
    
    int index = 0;
    foreach(var item in listA)
    {
       while(index < myList.Count && myList[index].ID < listA.ID)
          index++;
       if (index > myList.Count)
         break;
    
       if (myList[index].ID = item.ID)
       {
           myList[index] = item;
       }
    }
