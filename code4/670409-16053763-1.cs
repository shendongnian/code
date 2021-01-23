    public class EmployeeBinder : IModelBinder {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
                var emp = new Employee {
                                           Id = controllerContext.HttpContext.Request.Form["Id"],
                                           FirstName = controllerContext.HttpContext.Request.Form["FirstName"],
                                           LastName = controllerContext.HttpContext.Request.Form["LastName"],
                                           BirthDate = new DateTime(int.Parse(controllerContext.HttpContext.Request.Form["year"]),
                                               int.Parse(controllerContext.HttpContext.Request.Form["month"]),
                                               int.Parse(controllerContext.HttpContext.Request.Form["day"]))
                                       };
    
                return emp;
            }
        }
