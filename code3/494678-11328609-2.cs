    public class BaseController : Controller
        {
            protected override void ExecuteCore()
            {
                Type controllerType = this.ControllerContext.Controller.GetType();
                ControllerDescriptor controllerDescriptor = new ReflectedControllerDescriptor(controllerType);
    
                if (controllerDescriptor.IsDefined(typeof(SpecialSetUpAttribute), true))
                {
                    //Do special setup
                }
                else
                {
                    //Do normal setup
                }
                base.ExecuteCore();
            }
        }
