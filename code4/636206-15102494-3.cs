    public class MyModel
    {
        public IEnumerable<SelectListItem> mydropdown;
        public MyModel()
        {
             this.mydropdown=new []
             { 
                new SelectListItem{Value="value", Text="text"}
                ////...
             };
        }
    }
    public ActionResult Register()
    {
       MyModel mm=new MyModel();
    }
 
    
