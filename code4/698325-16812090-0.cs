    public class MyController : Controller
    {
        public ActionResult DoFirst(int id)
        {
            MySpclClass myObject = new MySpclClass(); // The model
            myObject.doOneThing(); // Set some properties on the model that are stored on the view as hiddenfields and will be posted back to the "DoSecond" action.
            return view("MyView", myObject);
        }
        [HttpPost]
        public ActionResult DoSecond(MySpclClass myObject) 
        {            
            myObject.doAnotherthing(); // Uses the properties that where stored on the view and posted back again.
            return view("MyView", myObject);
        }
    }
