    [STAThread]
        public static void Main(string[] args)
        {
            Task task = new Task(() => { Thread.Sleep(200); MessageBox.Show("what a marvelous engineering"); });
            task.Start();
            //If you want application not to run untill task is complete then just use wait
            task.Wait();
            
                App app = new App();
                app.InitializeComponent();
                app.Run();
        }
