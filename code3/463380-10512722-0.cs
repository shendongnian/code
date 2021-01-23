    public abstract class Entity<T>
    {
        public static event Action Saved = delegate { };
        internal virtual void OnSaved()
        {
            Saved();
        }
    }
    class Class1 : Entity<Class1>
    {
        //Stuff
    }
    class Class2 : Entity<Class2>
    {
        //Stuff
    }
