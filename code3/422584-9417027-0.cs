    class ClassWithStaticMembers
    {
        private static Random random = new Random();
    
        public static int ReturnAnIntStatic()
        {
            return random.Next();
        }
    
        public int ReturnAnInt()
        {
            return random.Next();
        }
    }
    
    class Program
    {
    
        static void Main()
        {
            var classWithStaticMembers = new ClassWithStaticMembers();
            Console.WriteLine(ClassWithStaticMembers.ReturnAnIntStatic());
            Console.WriteLine(classWithStaticMembers.ReturnAnInt());
            Console.ReadKey();
        }
    }
