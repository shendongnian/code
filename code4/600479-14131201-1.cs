    public class MyClass {
     private readonly int a = 0;
     public MyClass(int a) {
      this.a = a;
     }
     public void DoSomethingWithA() {
       Console.WriteLine(this.a);
       //a = 5 // don't try this at home kids
     }
    }
    new MyClass(5).DoSomethingWithA();
