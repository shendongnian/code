    public class FinalizerObject
    {
        public FinalizerObject(int n)
        {
            Console.WriteLine("Constructed {0}", n);
            this.n = n;
        }
        private int n;
        ~FinalizerObject()
        {
            while (true) { Console.WriteLine("Finalizing {0}...", n); System.Threading.Thread.Sleep(1000); }
        }
    }
