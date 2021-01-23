    public class Manager
    {
        private List<baseClass> _workers = new List<baseClass>();
        public void Initialize(ClassType type)
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            Type objType = Type.GetType(string.Format("{0}.{1},{0}", assemblyName, type.ToString()));
            var correctChild =  (baseClass)Activator.CreateInstance(objType);
            _workers.Add(correctChild);
        }
    }
