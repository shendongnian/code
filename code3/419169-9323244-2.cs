    class Program
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private class Sample
        {
            public Int32 length;
            public String value;
            public Sample(String s)
            {
                length = s.Length;
                value = s;
            }
        }
        [DllImport("C:\\Users\\Kep\\Documents\\Visual Studio 2010\\Projects\\SODLL\\Debug\\DLL.dll")]
        private static extern void helloWorld(Sample sample); 
        static void Main(string[] args)
        {
            Sample s = new Sample("Huhu");
            helloWorld(s);
        }
    }
