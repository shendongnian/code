    public class MyModel {
        public string MyValue { get; set;}
        public List<SelectListItem>  Options { get; set; }
    }
    public ActionResult MyAction(){
    
        MyModel model = new MyModel();
        // populate options here
        model.Options = new List<SelectListItem>();
        return View(model);
    }
