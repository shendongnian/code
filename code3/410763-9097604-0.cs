    public abstract class MyClass
    {
        private int _result;     
        public int Result { get { return _result; } }      
        public void GetRandomValue()     
        {         
            Random n = new Random();         
            _result = n.Next(1,100);     
        }
    }
