    namespace MyNamespace
    {
       public delegate void MyDelegate(object sender, EventArgs e);
       
       public class MyClass
       {
          public event MyDelegate OnSomethingHappened;
       }
    }
