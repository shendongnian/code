    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    class StringDescriptionAttribute : Attribute
    {
        private string _name;
        public StringDescriptionAttribute(string name)
        {
            _name = name;
        }
        public StringDescriptionAttribute(Type resourseType, string name)
        {
                _name = new ResourceManager(resourseType).GetString(name);
        }
        public string Name { get { return _name; } }
    }
