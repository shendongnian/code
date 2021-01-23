    public class BoxedInt
    {
        public int x;
        public BoxedInt(int i) { x = i; }
    }
    public Test()
    {
        BoxedInt bi = new BoxedInt(10);
        Boxed(bi);
        Console.WriteLine(bi.x); // Returns 11, as any reference type would.
        int vi = 10;
        Valued(vi);
        Console.WriteLine(vi); // Returns 10, because it acts like a struct. (Which it is)
    }
    public void Boxed(BoxedInt i)
    {
        i.x++;
    }
    public void Valued(int i)
    {
        i++;
    }
