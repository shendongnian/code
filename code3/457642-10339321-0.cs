    public ActionResult Details(int id)
    {
        var employee = employeeRepository.Get(id)
        var user = (CustomIdentity)ControllerContext.HttpContext.User.Identity;
        if(!employee.CanUserAccess(user))
            return new HttpUnauthorizedResult();
    
        // Normal logic here
    }
