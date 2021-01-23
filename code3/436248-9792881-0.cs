    public class Foo
    {
      public string strA;
    }
    Foo A = new Foo() { strA = "abc" };
    Foo B = A;
     B.strA = "abcd";            
            
     Console.WriteLine(A.strA);// abcd
     Console.WriteLine(B.strA);//abcd
