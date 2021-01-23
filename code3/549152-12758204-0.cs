    public class MyClass
    {
      public Variable Var1{ get; set; }
    }
    MyClass c = new MyClass();
    c.Var1 = v; //where v is an instance of Variable class
    //or
    Variable v = c.Var1; //returns an Instance of Variable which is a property of c
