    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                 App app = new App();
                 app.InitializeComponent();
                 app.Run();
            }
            catch (Exception e)
            {
                 // Log here
                 // Custom error message.
            }
         }
     }
