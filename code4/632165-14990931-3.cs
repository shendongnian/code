    public class ParentClass 
    {
        private static Dictionary<ClassType, Type> typesToCreate = ...
        // Generics are cool
        public static T GetNewObjectOfType<T>() where T : ParentClass
        {
            return (T)GetNewObjectOfType(typeof(T));
        }
        // Enums are fine too
        public static ParentClass GetNewObjectOfType(ClassType type)
        {
            return GetNewObjectOfType(typesToCreate[type]);
        }
        // Most direct way to do this
        public static ParentClass GetNewObjectOfType(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
