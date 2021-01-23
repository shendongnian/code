    public class MyClass
    {
        readonly int[] _cs = new int[n];
        public int[] Cs { get { return _cs; } }
        public int C1 { get { return Cs[0]; } set { Cs[0] = value; } }
        public int C2 { get { return Cs[1]; } set { Cs[1] = value; } }
        public int C3 { get { return Cs[2]; } set { Cs[2] = value; } }
        .
        .
        .
        public int Cn { get { return Cs[n-1]; } set { Cs[n-1] = value; } }
    }
