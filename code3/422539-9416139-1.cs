    public class OldClass : BaseClass, IOld
    {
        public override double Meth2(int input)
        {
            return 0.0;
        }
    }
    public class NewClass : OldClass, INew // now implements IOld and INew using the Method2() from OldClass
    {
        [Obsolete("This method is deprecated . Use Method3() instead.")]
        public override double Meth2(int input)
        {
            return base.Meth2(input);
        }
        public float Meth3(int input)
        {
            return return 0.0f;
        }
    }
