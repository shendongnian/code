    public class MyObject
    {
       public string Name { get; set; }
       public string Something1{ get; set; }
       public string Something2{ get; set; }
       public string Something3 { get; set; }
       public string Something4 { get; set; }
       public string Color { get; set; }
    }
    
    [GridAction]
    public ActionResult GetData()
    {
       var data = QueryDatabaseAndInstantiateAListOfMyObjects();
       data.Something4 = MyObject2.Something4;
       data.Color = MyObject2.Color;
       return View(new GridModel(data));
    }
