    public class MyModel
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        ...
    }
    [AjaxOnly]
    public ActionResult Show(MyModel model)
    {
        // use model
    }
