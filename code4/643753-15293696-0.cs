    abstract class Clazz<T>
    {
       public abstract void CopyFrom(Clazz<T> source);
       public abstract void ProcessList<TDescendant>(List<TDescendant> list)
           where TDescendant : Clazz<T>;
    }
    class MyClass : Clazz<MyClass>
    {
        public override void CopyFrom(Clazz<MyClass> source)
        {
            // implementation
        }
        public override void ProcessList<TDescendant>(List<TDescendant> list)
        {
            // implementation
        }
    }
