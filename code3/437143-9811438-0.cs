    List<Item> Items = new List<Item>();
                
    myList.ForEach((item)=>
    {
       var items = item.Where(q=> q.Action == "123" && q.Name =="ABC");
       Items.AddRange(items);
    });
