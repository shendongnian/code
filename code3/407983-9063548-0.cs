    private Form SelectForm(string fileName,string formName)
    {
        Assembly assembly = Assembly.LoadFrom(fileName);
        var asmTypes = assembly.GetTypes().Where(F => F.IsSubclassOf(typeof(Form)));
        Type t = asmTypes.Single<Type>(F => F.Name == formName);
        try
        {
            var ctor = t.GetConstructors()[0];
            List<object> parameters = new List<object>();
            foreach (var param in ctor.GetParameters())
            {
                parameters.Add(GetNewObject(param.ParameterType));
            }
            return ctor.Invoke(parameters.ToArray()) as Form;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        return null;
    }
...
    public static object GetNewObject(Type t)
    {
        try
        {
            return t.GetConstructor(new Type[] { }).Invoke(new object[] { });
        }
        catch
        {
            return null;
        }
    }
