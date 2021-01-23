    public class C { public int P { get; set; } }
    public class X
    {
        static void M(C c1, C c2, ref C c3, ref C c4)
        {
          c1.P = 11;
          c2 = new C() { P = 12 };
          c3.P = 13;
          c4 = new C() { P = 14 };
        }
        static void Main()
        {
          C q1 = new C() { P = 1 };
          C q2 = new C() { P = 2 };
          C q3 = new C() { P = 3 };
          C q4 = new C() { P = 4 };
          M(q1, q2, ref q3, ref q4);
          Console.WriteLine(q1.P);
          Console.WriteLine(q2.P);
          Console.WriteLine(q3.P);
          Console.WriteLine(q4.P);
        }
    }
