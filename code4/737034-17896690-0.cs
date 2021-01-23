    [AttributeUsage(AttributeTargets.Method)]
    public class MyAttribute : Attribute
    {
        public void MyAttributeInvoke(object source)
        {
            source.GetType()
                  .GetProperties()
                  .ToList()
                  .ForEach(x => Console.WriteLine(x.Name));
        }
    }
