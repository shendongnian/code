    public class MyClass
    {
        public ICollection InputObject
        {
            get { return inputObject; } 
            set { inputObject= value; }  // you should add some type checking here 
                                         //to make sure an invalid collection type isn't passed in
        }
        private ICollection inputObject;
        public Collection<T> GetTypedCollection<T>()
        {
            return (Collection<T>)inputObject; 
        }
    }
