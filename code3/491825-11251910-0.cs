    class Container
    {
        private Dictionary<Type, Action> dict;
    
        public bool AddAction(Type t, Action a) 
        {
            if (t.IsAssignableFrom(typeof(SomeParentClass))
            { 
                dict[t] = a;
                return true;
            }
            return false;
        }
    }
