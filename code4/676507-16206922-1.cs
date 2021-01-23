    class MyClass
    {
        public void Func<SomeParameterType,SomeReturnType> myDelegate {get;set;}
        public SomeReturnType myFunction(SomeParameterType parameter)
        {
            if(myDelegate==null)
                throw new Exception();
            return myDelegate(parameter);
        }
    }
    
    ...
    
    MyClass obj = new MyClass();
    SomeParameterType p = new SomeParameterType();
    obj.myDelegate = (x)=>new SomeReturnType(x);
    SomeReturnType result = obj.myFunction(p);
