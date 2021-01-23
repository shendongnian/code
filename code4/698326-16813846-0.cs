    public class MyController : Controller
    {
     private readonly IMySpclClass _mySpclClass;
    public void MyController(IMySpclClass mySpclClass)
    {
         _mySpclClass = mySpclClass;
    }
    public ActionResult DoFirst(int id)
    {
        _myObject.doOneThing(); // Set some properties on the model that are stored on the view as hiddenfields and will be posted back to the "DoSecond" action.
        return view("MyView", myObject);
    }
    [HttpPost]
    public ActionResult DoSecond(MySpclClass myObject) 
    {            
       _myObject.doAnotherthing(); // Uses the properties that where stored on the view and posted back again.
        return view("MyView", myObject);
    }
    }
     //and add the below code to ninject factor class
     _kernel.Bind<IMySpclClass >().To<MySpclClass >().InSingletonScope();
     //also intialize _kernel above as shown
     private static IKernel _kernel;
        public static void Register()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }
        private static IKernel Instance
        {
            get { return _kernel; }
        }
         and write all the bindings in the AddBindings() function
