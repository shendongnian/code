    class Container
    {
        private Dictionary<Type, Action> dict;
    
        public bool AddAction(Type t, Action a) 
        {
            if (typeof(SomeParentClass).IsAssignableFrom(t))
            { 
                dict[t] = a;
                return true;
            }
            return false;
        }
    }
