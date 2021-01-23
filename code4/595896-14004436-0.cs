        public static class Program
        {
            private static MyApp activeInstance;
        
            [STAThread]
            public static void Main()
            {
                if (activeInstance == null)
                {
                    activeInstance = new MyApp();
                    Application.Run(activeInstance);
                }
            }
        }
