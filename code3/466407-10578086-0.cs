    public class B : A {  
    public override void M(X x) {
             Console.WriteLine(this.GetType());
             x.XMethod(this);
         } 
    } 
