        public abstract class PersistentList<T>
        {
            public PersistentList<T> GetInstanceOfDerivedClass()
            {
                return (PersistentList<T>)Activator.CreateInstance(this.GetType());
            }
        }
