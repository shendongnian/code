    class ClassFromList<T>
    {
        public object Instance { get; set; }
        public ClassFromList(List<string> list)
        {
            var type = new DynamicClass().Builder;
            list.ForEach(item => new DynamicProperty<T>(type, item));
            Instance = Activator.CreateInstance(type.CreateType());
        }
    }
