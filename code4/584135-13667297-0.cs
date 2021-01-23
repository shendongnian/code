    [HttpPost]
    public ActionResult collect(FormCollection collection)
    {
         List<string> names = Request.Params
        .Cast<string>()
        .Where(p => p.StartsWith("somename"))
        .ToList();
       //  then iterate thru your dynamically created controls
       foreach(var item in names)
       {
          string text=collection[item].ToString();
    
       } 
     }
