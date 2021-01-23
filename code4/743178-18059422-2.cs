    public class A
    {
        private static int x;
    
        public int X
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get { return x; }
        }
    }
