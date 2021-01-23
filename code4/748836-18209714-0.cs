    interface MyInterface
    {
        public void Foo();
    }
    public partial class MyClass : Form, MyInterface
    {
       //More stuff stuff stuff. This is the form
    }
    Form f = new MyClass();
    f.ShowDialog(); // Works because MyClass implements Form
    f.Foo(); // Works because MyClass implements MyInterface
