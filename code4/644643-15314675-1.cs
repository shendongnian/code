    public class Class1
    {
       public void Function()
       { ... }
    }
    public class Class2
    {
       public void AnotherFunction()
       {
          Class1 class1 = new Class1();
          class1.Function();
       }
    }
