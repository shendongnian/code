    public class MyModel
    {
        public bool AutoReload {get; set;}
    }
    ....
    
    public ActionResult DoSomething(MyModel model) 
    {
        if (model.AutoReload)
            /* do something */
    }
