    public delegate void PropertyChangedEventHandler();
    public abstract class Base
    {
    }
    public class A : Base
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _value;
        public int Value
        {
            get { return _value; }
            set 
            { 
                _value = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged();
            }
        }
    }
    public class B : Base
    {
        private A _a;
        public B(A a)
        {
            _a = a;
            a.PropertyChanged += new PropertyChangedEventHandler(a_PropertyChanged);
        }
        private void  a_PropertyChanged()
        {
 	        Console.WriteLine(_a.Value);
        }
    }
    public class Application()
    {
        public void DoStuff()
        {
            var a = new A();
            var b = new B(a);
        }
    }
