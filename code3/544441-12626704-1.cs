    public interface I
    {
        int Prop { get; }
    }
    public abstract class A : I
    {
        public abstract int Prop { get; protected set; }
        public abstract int Prop2 { get; }
    }
    public class B : A
    {
        public override int Prop
        {
            get;
            set; // ERROR: Cannot change accesibility here.
        }
        public override Prop2 { get; set; } // ERROR: Cannot add setter here.
    }
    public class C : I
    {
        public int Prop { get; set; } // OK: Adding a setter works here.
    }
