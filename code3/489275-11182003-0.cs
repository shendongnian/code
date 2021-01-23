    interface IPersistentList<T> 
    {
        // TODO: Define members...
    }
    
    abstract class PersistentListBase
    {
        public static PersistentListBase GetInstanceOfDerivedClass()
        {
            return new Managers();
        }
    }
    
    class Manager { }
    
    class Managers : PersistentListBase, IPersistentList<Manager> { }
