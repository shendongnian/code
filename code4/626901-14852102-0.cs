    public class Library
    {
        private static class Native
        {
            [DllImport("foobar.dll")]
            public static extern void Initialize();
            [DllImport("foobar.dll")]
            public static extern void Settings(int param1, string param2);
            [DllImport("foobar.dll")]
            public static extern float[] Intermediate(float[] input);
            [DllImport("foobar.dll")]
            public static extern void MainMethod(float[] main);
        }
        private static readonly object sync = new object();
        private int param1;
        private string param2;
        static Library()
        {
            Native.Initialize();
        }
        public void Settings(int param1, string param2)
        {
            this.param1 = param1;
            this.param2 = param2;
        }
        public float[] Intermediate(float[] input)
        {
            lock (sync)
            {
                Native.Settings(param1, param2);
                return Native.Intermediate(input);
            }
        }
        public void MainMethod(float[] input)
        {
            lock (sync)
            {
                Native.Settings(param1, param2);
                Native.MainMethod(input);
            }
        }
    }
