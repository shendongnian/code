    public static List<T> CreateList<T>(T baseA, int length) where T : IA
    {
        var myList = new List<T>();
        for (int i = 0; i < length; i++)
        {
            myList.Add((T)baseA.Clone());
        }
        return myList;
    }
    public interface IA
    {
        public abstract IA Clone();
    }
    public abstract class A<TContentType> : IA
    {
        public abstract void Initialise();
        public TContentType Value { get; private set; }
    }
    public class B : A<double>
    {
        public override IA Clone()
        {
            var b = new B();
            // transfer properties
            return b;
        }
        //public override void Initialise() { this.Value = 3.0; }
    }
    public class C : A<char>
    {
        public override IA Clone()
        {
            var c = new C();
            // transfer properties
            return c;
        }
        //public override void Initialise() { this.Value = 'v'; }
    }
