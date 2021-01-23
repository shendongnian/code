    [STAThread]
            static void Main(string[] args)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Main_Form main = new Main_Form();
                main.Show();
                foreach (string s in args)
                {
                    if (s == "-h")
                    {
                        main.Hide();
                    }
                }
                Application.Run();
            }
