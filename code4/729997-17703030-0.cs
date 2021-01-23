    public struct Test
    {
       public int a;
       public Decimal b;
       public DateTime c;
    
       public void Output(){
    
          Console.WriteLine ("a: " + a);
          Console.WriteLine ("b: " + b);
          Console.WriteLine ("c: " + c);
    
       }
    }
    var t = new Test();
    t.Output();
