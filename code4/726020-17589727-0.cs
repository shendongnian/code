        public class MyClass<T>
        {
            public T TheGeneric { get; set; }
        }
    
        Type theType = typeof(MyClass<>);
