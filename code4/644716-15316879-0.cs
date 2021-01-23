        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm = new Form1();
            var gameboard = new GameBoard(mainForm);
            Application.Run(mainForm);
        }
