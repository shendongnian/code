    [ComVisibleAttribute(true)]
    public class MyClass { ... }
    ...
    Type classType = typeof(MyClass);
    object[] attrs = classType.GetCustomAttributes(true);
    foreach (object attr in attrs)
    {
        ComVisibleAttribute comVisible = attr as ComVisibleAttribute;
        if (comVisible != null)
        {
            return comVisible.Value // returns true
        }
    }
