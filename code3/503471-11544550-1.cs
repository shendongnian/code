    class X
    {
        private int[] amazing = new int[10];
        public int[] Amazing { get { return this.amazing; } }
    }
    X a = new X();
    int[] x = a.Amazing;
    int[] y = a.Amazing;
    x[2] = 9;
    Debug.Assert(x[2] != y[2]); // Fails!
