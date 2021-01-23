    abstract class Persistable<T>
    {
        protected static Func<long, T> mapFunction;
        public static T Get(long id)
        {
            return mapFunction(id);
        }
    }
    class Entity : Persistable<Entity>
    {
        public static Entity()
        {
            Persistable<Entity>.mapFunction = input => EntityDao.Get(input);
        }
    }
    class Value : Persistable<Value>
    {
        public static Value()
        {
            Persistable<Value>.mapFunction = input => ValueDao.Get(input);
        }
    }
