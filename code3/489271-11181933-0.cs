    static class PersistentList
    {
        public static T GetInstanceOfDerivedClass<T, U>() where T : PersistentList<U>
        {
            throw new NotImplementedException();
        }
    }
    Managers managers = PersistentList.GetInstanceOfDerivedClass<Managers, Manager>();
