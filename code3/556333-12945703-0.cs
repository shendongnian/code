    public interface iFoo
    {
        string FoundItem { get; set; }
        string Expression { get; }
        string Value { get; set; }
        void sharedFunctionName();
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
