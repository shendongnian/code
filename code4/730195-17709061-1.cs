        private static void Main(string[] args)
        {
            IFoo foo = new IFoo(); // <- interface
            foo.Print();
            Console.ReadKey();
        }
        [ComImport, Guid("A7D5E89D-8FBD-44B7-A300-21FAB4833C00"), CoClass(typeof(Foo))]
        public interface IFoo
        {
            void Print();
        }
        public class Foo : IFoo
        {
            public void Print()
            {
                Console.WriteLine("Hello!");
            }
        }
