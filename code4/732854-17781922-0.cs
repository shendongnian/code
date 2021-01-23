    static class Program
    {
        public static Form1 myFormInstance;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run((myFormInstance= new Form1()));
        }
    }
    static class MyClass
    {
        static void DoWorkWithForm()
        {
              Program.myFormInstance.Controls.Add(/**/);
        }
    }
