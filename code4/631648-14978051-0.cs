    foreach(var item in list)
    {
        if(list.Count(e=>e.Id == item.Id && e.Name == item.Name)!=1)
        {
            list.Remove(item);
        }
    }
