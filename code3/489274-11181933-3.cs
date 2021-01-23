    abstract class PersistentList<T, U> where T : PersistentList<T, U>
    {
        public static T GetInstanceOfDerivedClass()
        {
            throw new NotImplementedException();
        }
    }
    public class Managers : PersistentList<Managers, Manager>
    {
    }
