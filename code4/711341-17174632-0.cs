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
    
                Form1 f = new Form1();
                f.KeyPreview = true;
                f.KeyDown += f_KeyDown;
                Application.Run(f);
            }
    
            static void f_KeyDown(object sender, KeyEventArgs e)
            {
                MessageBox.Show(e.KeyValue.ToString());
            }
        }
