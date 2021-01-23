       public interface IMyInterface
    {
        int Metoda1()enter code here`;
    }
    public class MyClass : test.IMyInterface
    {
        public IMyInterface Metoda1()
        {
            return new MyClas();
        }
        int test.IMyInterface.Metoda1()
        {
            return 1;
        }
    }
       static void Main(string[] args)
        {
            MyClass instance = new MyClass();
            IMyInterface inst = instance.Metoda1();
         /*   IMyInterface ints2 = inst.Metoda1(); //will not compile*/
            Console.WriteLine(inst.GetType().ToString()); ;
            object inst3 = inst.Metoda1();
            Console.WriteLine(inst3.GetType().ToString());
        }
