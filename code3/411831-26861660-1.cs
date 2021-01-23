        private static readonly Dictionary<string, KeyValuePair<TConstructor, Node>> Types =
            new Dictionary<string, KeyValuePair<TConstructor, Node>>();
        private static readonly Dictionary<Type, string> classNameMap = new Dictionary<Type, string>();
        private class constructableNode<T> where T : Node, new()
        {
            public constructableNode()
            {
                var t = new T();
                Types[t.Type()] = new KeyValuePair<TConstructor, Node>(thisTConstructor, t);
                classNameMap[typeof (T)] = t.Type();
            }
            private static T thisTConstructor()
            {
                var t = new T();
                return t;
            }
        }
        public static Node GetA(string s)
        {
            if (Types.ContainsKey(s) == false)
            {
                UpdateAvailableTypes();
            }
            if (Types.ContainsKey(s) == false)
            {
                throw new BadNodeType(s);
            }
            // look up the correct constructor, and call it.
            return Types[s].Key();
        }
        public static void UpdateAvailableTypes()
        {
            Assembly targetAssembly = Assembly.GetExecutingAssembly(); // or whichever - could iterate dlls in the plugins folder or something
            UpdateAvailableTypes(targetAssembly);
            classNameMap[typeof (Node)] = "BaseNode"; // HARD CODED INTO the node type itself also
        }
        private static void UpdateAvailableTypes(Assembly targetAssembly)
        {
            IEnumerable<Type> subtypes = targetAssembly.GetTypes().Where(t => t.IsSubclassOf(typeof (Node)));
            Type nodeConstructor = typeof (constructableNode<>);
            foreach (Type currentType in subtypes)
            {
                // this line throwing an error means that the Node type does not have an empty constructor.
                Activator.CreateInstance(nodeConstructor.MakeGenericType(currentType));
            }
        }
