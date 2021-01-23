    class ClassFromList<T>
    {
        public Type Type { get; set; }
        public ClassFromList(List<string> list)
        {
            var type = new DynamicClass().Builder;
            list.ForEach(item => new DynamicProperty<T>(type, item));
            Type = type.CreateType();
        }
    }
