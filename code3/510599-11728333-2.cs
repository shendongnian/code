    static IEnumerable<Type> GetTypesWithAttribute(Assembly assembly)
    {
        foreach (Type type in assembly.GetTypes())
        {
            yield return type;
        }
    }
    static IEnumerable<MethodInfo> GetMethodsWithAttribute(Type theClass)
    {
        foreach (MethodInfo method in theClass.GetMethods())
        {
            if (method.GetCustomAttributes(typeof(QTestAttribute), true).Length > 0)
            {
                yield return method;
            }
        }
    }
    public ActionResult Index()
    {
        IEnumerable<Type> classes = GetTypesWithAttribute(Assembly.LoadFrom(HttpContext.Request.MapPath(@"~\bin\YourProjectName.dll")));
        List<String> tests = new List<string>();
        foreach (var singleClass in classes)
        {
            try
            {
                var a = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(singleClass.FullName);
                foreach (MethodInfo method in GetMethodsWithAttribute(singleClass))
                {
                    tests.Add(method.Invoke(a, null).ToString());
                }
            }
            catch (Exception)
            {
            }
        }
        return Content(string.Join("<br>", tests));
    }
