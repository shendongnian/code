    class MyClass<T>
    {   
        private Type _type = typeof(string);
        public MyClass()
        {
            this._type = typeof(T);
        }
        public List<T> MyList { get; set; }  <----it likes this
    }
