     public class BaseController : Controller
            {
                protected override void ExecuteCore()
                {
                    Type controllerType = this.ControllerContext.Controller.GetType();
                    ControllerDescriptor controllerDescriptor = new ReflectedControllerDescriptor(controllerType);
    
    // Edit start
                    string actionName = Convert.ToString(this.ControllerContext.RouteData.Values["action"]);
                string controller = Convert.ToString(this.ControllerContext.RouteData.Values["controller"]);
    
    // Edit end
        
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
