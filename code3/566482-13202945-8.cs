    public static IEnumerable<MethodInfo> GetActions(string controller, string action)
    {
        return Assembly.GetExecutingAssembly().GetTypes()
               .Where(t =>(t.Name == controller && typeof(Controller).IsAssignableFrom(t)))
               .SelectMany(
                    type =>
                    type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .Where(a => a.Name == action && a.ReturnType == typeof(ActionResult))
                 );
    }
