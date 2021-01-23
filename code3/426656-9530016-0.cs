    class DuplicateInterfaceClass : MyInterface1, MyInterface2
    {
     public void DuplicateMethod()
     {
      Console.WriteLine("DuplicateInterfaceClass.DuplicateMethod");
     }
     string MyInterface1.P
     { get { return "DuplicateInterfaceClass.P"; } }
     string MyInterface2.P()
     { return "DuplicateInterfaceClass.P()"; }
     public string P()
     { return ((MyInterface2)this).P(); }
    }
