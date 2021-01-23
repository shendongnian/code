     public class Foo 
     {
         // define the shape of our event handler
         public delegate void HandlerForBarEvent(object sender, EventArgs args);
         // declare our event
         public event HandlerForBarEvent BarEvent;
         public void CallBar()
         {
             // omitted: check for null or set a default handler
             BarEvent(this, new EventArgs());
         }
     }    
     public void Main(string[] args)
     {
          var foo = new Foo();
          // declare the handler inline using lambda syntax
          foo.BarEvent += (sender, args) => 
          {
               // do something with sender/args
          }
          foo.CallBar();
     }
