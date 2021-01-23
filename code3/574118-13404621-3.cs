    List<MyItem> items = new List<MyItem>();
    
    while (reader.Read())
    {
        MyItem item = new MyItem();
        item.State = reader[0].ToString(); 
        item.Capital = reader[1].ToString(); 
        // etc
        items.Add(item);
    }
    
    return Json(new {  myTable = items }, JsonRequestBehavior.AllowGet);
