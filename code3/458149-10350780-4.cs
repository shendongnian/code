    public ActionResult Edit(int id,string from)
    {
      EditItemViewModel item=GetItem(id);
      item.From=from;      
      return View(item);
    }
