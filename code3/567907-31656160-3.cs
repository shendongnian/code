    public class Thing
    {
        public int id { get; set; }
        public string color { get; set; }
    }
     
    public JsonResult MethodTest(IEnumerable<Thing> datav)
        {
       //now  datav is having all your values
      }
