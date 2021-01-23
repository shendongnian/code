    public class CustomAttribute : Attribute
    {
        ...
    }
    MyClass mc = new MyClass();
    PropertyInfo[] allProps = mc.GetType()
        .GetProperties()
        .Where(x => x.GetCustomAttributes(typeof(CustomAttribute)).Length > 0)
        .ToArray();
