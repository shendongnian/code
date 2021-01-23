    var myStudent = new Student("John").Named("myStudent");
    var nameOfInstance = myStudent.Name();
    public static class ObjectExtensions
    {
        private static Dictionary<object,string> namedInstances = new Dictionary<object, string>(); 
        public static T Named<T>(this T obj, string named)
        {
            if (namedInstances.ContainsKey(obj)) namedInstances[obj] = named;
            else namedInstances.Add(obj, named);
            return obj;
        }
        public static string Name<T>(this T obj)
        {
            if (namedInstances.ContainsKey(obj)) return namedInstances[obj];
            return obj.GetType().Name;
        }
    }
