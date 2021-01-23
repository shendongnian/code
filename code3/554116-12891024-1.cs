    public partial class Form1 : Form
    {
         private Foo _foo;
         // without dependency injection: private Foo _foo = new Foo();         
    
         public Form1(Foo foo)
         {
             _foo = foo;
         }
         
         protected void button3_Click(object sender, EventArgs e)
         {
             _foo.Output();
         }
    }
