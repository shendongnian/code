    static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                FrmMain mainForm = new FrmMain();
                FrmUsername us = new FrmUsername();
                if (us.ShowDialog() != DialogResult.OK)
                    return;
                Application.Run(mainForm);
            }
