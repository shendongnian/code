     public class Baz {
         private Foo _myFoo = new Foo(1);
         public Foo MyFoo {
             get{
                return _myFoo;
             }
         }
     }
    Foo bar = new Baz();
    bar.MyFoo.x = 789; // <-- returning a copy of _myFoo not a reference to that object
    if(barMyFoo.x == 1){
       Console.WriteLine("This will be written to console because bar.x is 1!");
    }
