       public interface IMyInterface
        {
            object Metoda1(string txt);
        }
    class MyClass:IMyInterface
    {
    
          public MyClass Method(string txt)
            {
                Console.WriteLine(txt);
                return new MyClass();
            }
           object test.IPolymorpfism.Method(string txt)
           {
               Console.WriteLine(txt);
               return new MyClass() ;
           }
    }
