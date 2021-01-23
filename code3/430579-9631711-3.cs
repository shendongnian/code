    class SplashForm : Form
    {
         public SplashForm()
         {
             InitializeComponent();
             new Thread(run).Start();
         }
         private void run()
         {
             Thread.Sleep(5000);
             this.Invoke((MethodInvoker)delegate
             {
                 this.Close();
             });
         }
     }
   
