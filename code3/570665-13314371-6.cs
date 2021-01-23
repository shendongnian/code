    /**CODE**/
        class Program
        {
            public static void Main(string[] args)
            {
                B myClass = new C();
                Console.WriteLine(myClass.GetContainerType()); //should output StackOverflow.Demos.B
                Console.ReadKey();
            }
        }
        public interface IGetContainerType
        {
            Type GetContainerType();
        }
        
        public class A: IGetContainerType 
        { 
            public A() { }
            public Type GetContainerType()
            {
                return typeof(A);
            }
        }
        public class B : A
        {
            public B() { }
            public new Type GetContainerType()
            {
                return typeof(B);
            }
        }
        public class C : B
        {
            public C() { }
            public new Type GetContainerType()
            {
                return typeof(C);
            }
        }
    /**OUTPUT**/
        StackOverflow.Demos.B
