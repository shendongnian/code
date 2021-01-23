    public abstract class A
    {
     protected A(string v) { V = v; }
     public string V { get; protected set; }
    }
    
    public class AA : A
    {
     public AA(string v) : base (v) {}
    }
