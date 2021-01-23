    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text Files | *.txt";
            openFile.ShowDialog();          
            StreamReader infile = File.OpenText(openFile.FileName);
            ...
            Application.Run(new Form1());
        }
    }
