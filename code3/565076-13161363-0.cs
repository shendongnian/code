    class Test<T>
    {
        T value;
        public void SetV(T newValue)
       {
       if(object.Equals(newValue,value))
       //We have to use Object.Equals cant use == or !=since they cannot bind to unknown type at compile time
       }
    }
