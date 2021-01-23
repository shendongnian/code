        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form form;
            StreamReader tr = new StreamReader(Application.StartupPath + "\\" + "config.txt");
            string config = tr.ReadToEnd();
            tr.Close();
            if (string.IsNullOrWhiteSpace(config))
            {
                form = new Configuration_Form();
            }
            else
            {
                form = new Form1();
            }
            Application.Run(form);
        }
