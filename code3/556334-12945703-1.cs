    public interface iFoo
    {
        string FoundItem { get; set; }
        string Expression { get; }
        void sharedFunctionName();
    }
    public interface iFoo<T> : iFoo
    {
        T Value { get; set; }
    }
    public static class FooFactory
    {
        public static List<iFoo> GetTypeList()
        {
            List<iFoo> types = new List<iFoo>();
            types.AddRange(from assembly in AppDomain.CurrentDomain.GetAssemblies()
                           from t in assembly.GetTypes()
                           where t.IsClass && t.GetInterfaces().Contains(typeof(iFoo))
                           select Activator.CreateInstance(t) as iFoo);
            return types;
        }
    }
    public class FooBar : iFoo<int>
    {
    }
