    class MyClass
    {   
        private Type _type = typeof(string);
        public MyClass(Type type)
        {
            this._type = typeof(type);
            this.MyList = Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
        }
        public IList MyList { get; set; }  <----it likes this
    }
