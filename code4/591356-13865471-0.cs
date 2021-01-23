    internal interface IHaveAMethod
    {
        String GetString();
    }
    public ActionResult Contact()
    {
        ViewBag.Message = GetValue(new ClassOne());
        return View();
    }
    public String GetValue<T>(T customClass) where T : IHaveAMethod
    {
        return customClass.GetString();
    }
    private class ClassOne : IHaveAMethod
    {
        public String GetString()
        {
            return "ClassOneMethod";
        }
    }
    private class ClassTwo : IHaveAMethod
    {
        public String GetString()
        {
            return "ClassTwoMethod";
        }
    }
