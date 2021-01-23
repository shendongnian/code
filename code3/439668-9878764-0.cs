        class Program
        {
            static void Main(string[] args)
            {
            var a = new MyClass("A");
            var b = new MyClass("B");
    
            Console.WriteLine(a == b);
            Console.WriteLine(b == a);
    
            Console.ReadLine();
        }
        
        
        public class MyClass
        {
    
        private string _Name;
    
        public MyClass(string name)
        {
            if (_FirstInstance == null)
            {
                _FirstInstance = this;
            }
            this._Name = name;
        }
    
        private static MyClass _FirstInstance = null;
    
        public static bool operator ==(MyClass left, MyClass right)
        {
            return object.ReferenceEquals(left, _FirstInstance);
        }
    
        public static bool operator !=(MyClass left, MyClass right)
        {
            return !(left == right);
        }
    }
 
