    public interface I
    {
        bool equals(I other);
    }
    public class C1 : I
    {
        public virtual bool equals(I other)
        {
            Console.WriteLine("C1.equals");
            return false;
        }
    }
    public class C2 : C1
    {
        public override bool equals(I other)
        {
            Console.WriteLine("C2.equals");
            return false;
        }
    }
