    List<string> newList = new List<string>();
    mylist.ForEach((item)=>
      {
        item=item.Replace("mph",""); 
        newlist.Add(item);
      });
