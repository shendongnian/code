    public class X 
    {
        private object _propertyName;
        public object PropertyName
        {
             get { return _propertyName; }
             set 
             {
                 _propertyName = value;
                 doSomething();
             }
        }
    }
