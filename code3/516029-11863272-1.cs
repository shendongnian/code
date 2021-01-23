    var obj = Activator.CreateInstance(Type.GetType("SO.Form2+Person"));
    foreach (var pi in obj.GetType().GetProperties())
    {
        pi.SetValue(obj, Convert.ChangeType(parameters[pi.Name], pi.PropertyType));
    }
--
    public class Person
    {
        public string Name { set; get; }
        public int  Age { set; get; }
    }
