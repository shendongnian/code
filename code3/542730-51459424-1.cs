    namespace InterviewPreparation
    {
       public abstract class baseclass
        {
            public abstract void method1(); //abstract method
            public abstract void method2(); //abstract method
            public void method3() { }  //Non- abstract method----->It is necessary to implement here.
        }
        class childclass : baseclass
        {
            public override void method1() { }
            public override void method2() { }
        }
        public class Program    //Non Abstract Class
        {
            public static void Main()
            {
                baseclass b = new childclass(); //create instance
                b.method1();
                b.method2();
                b.method3();
            }
        }
       
    }
