    class Program
    {
        static void Main(string[] args)
        {
            var a = new SubA();
            var b = new SubB();
        }
    }
    
    class BaseClass
    {
        public BaseClass()
        {
            Type t = GetType();
            if (t.IsDefined(typeof(SerializableAttribute), false) == false)
            {
                Console.WriteLine("bad implementation");
                throw new InvalidOperationException();
            }
            Console.WriteLine("good implementation");
        }
    }
    
    [Serializable]
    class SubA : BaseClass
    { }
    
    class SubB : BaseClass
    { }
