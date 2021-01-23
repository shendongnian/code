    public class ParentClass 
    {
        // Generics are cool
        public static T GetNewObjectOfType<T>() where T : ParentClass
        {
            return (T)GetNewObjectOfType(typeof(T));
        }
        public static ParentClass GetNewObjectOfType(Type type)
        {
            return Activator.CreateInstance(type)
        }
    }
