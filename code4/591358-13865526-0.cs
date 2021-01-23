    public ActionResult Contact()
    {
        ViewBag.Message = GetValue<MyInterface>(new ClassOne());
        return View();
    }
    
    public string GetValue<T>(T customClass, string type)
    {
        return customClass.MyMethod
    }
    
    class ClassOne : IMyInterface
    {
        public string MyMethod()
        {
            return "ClassOneMethod";
        }
    }
    
    class ClassTwo : IMyInterface
    {
        public string MyMethod()
        {
            return "ClassTwoMethod";
        }
    }
    
    public Interface IMyInterface
    {
        string MyMethod();
    }
