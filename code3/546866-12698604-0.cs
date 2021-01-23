    public static T Cast<T>(object o)
    {
      return (T)o;
    }
    obj = Activator.CreateInstance(prop.PropertyType);
    MethodInfo castMethod = typeof(MainClass).GetMethod("Cast").MakeGenericMethod(prop.PropertyType);
    prop.SetValue(parent, castMethod.Invoke(null, new object[] { obj }), null);
