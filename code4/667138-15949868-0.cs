    interface IClass<T>  where T : IClass<T>
    {
         string print(T item);
    }
    class MyClass : IClass<MyClass>
    {
        public string print(MyClass item)
        { 
           return item.ToString(); 
        }
    }
