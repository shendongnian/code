    var innerType = Assembly.GetExecutingAssembly().GetTypes()
                    .Where(t => t.DeclaringType == typeof(Outer))
                    .First(t => t.Name == "Inner");
    var innerObject = Activator.CreateInstance(innerType);
    innerType.GetMethod("InnerTest", BindingFlags.Instance | BindingFlags.NonPublic)
             .Invoke(innerObject, new object[] { });
--
    public class Outer
    {
        class Inner
        {
            internal void InnerTest()
            {
                Console.WriteLine("test");
            }
        }
    }
