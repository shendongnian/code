        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var main = new Form1();
            using (var gr = main.CreateGraphics()) {
                if (gr.DpiX != 96) {
                    MessageBox.Show("Sorry, didn't get this done yet.  Bye");
                    Environment.Exit(1);
                }
            }
            Application.Run(main);
        }
