        public delegate bool CancelationPending();
        [DllImport("YourDll.dll", CallingConvention = CallingConvention.StdCall)]
        public static unsafe extern void ProcessBarrelDistortion
        (byte* bytes, 
         int stride, 
         int width, 
         int height, 
         byte pixelSize, 
         double a, 
         double b, 
         double c, 
         double d,
         CancelationPending cancelationPending);
        static void Main(string[] args)
        {
            var bg = new BackgroundWorker {WorkerSupportsCancellation = true};
            bg.DoWork += (sender, eventArgs) =>
            {
                Console.WriteLine("Background work....");
                Thread.Sleep(10000);
            };
            bg.RunWorkerAsync();
            unsafe
            {
                ProcessBarrelDistortion(null, 0, 0, 0, 0, 0, 0, 0, 0, 
                   () => bg.CancellationPending);
            }
            bg.CancelAsync();
            unsafe
            {
                ProcessBarrelDistortion(null, 0, 0, 0, 0, 0, 0, 0, 0, 
                    () => bg.CancellationPending);    
            }
            
            
        }
