        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var consoleWriter = new ConsoleWriter())
            {
                consoleWriter.WriteEvent += consoleWriter_WriteEvent;
                consoleWriter.WriteLineEvent += consoleWriter_WriteLineEvent;
                Console.SetOut(consoleWriter);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
        static void consoleWriter_WriteLineEvent(object sender, Program.ConsoleWriterEventArgs e)
        {
            MessageBox.Show(e.Value, "WriteLine");
        }
        static void consoleWriter_WriteEvent(object sender, Program.ConsoleWriterEventArgs e)
        {
            MessageBox.Show(e.Value, "Write");
        }
