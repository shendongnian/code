    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var thread = new Thread(ThreadStart);
            // allow UI with ApartmentState.STA though [STAThread] above should give that to you
            thread.TrySetApartmentState(ApartmentState.STA); 
            thread.Start(); 
            
            Application.Run(new frmOne());
        }
        private static void ThreadStart()
        {
            Application.Run(new frmTwo()); // <-- other form started on its own UI thread
        }
    }
