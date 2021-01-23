            public static Form1 s_mainForm = null;
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                s_formShutdownMsg = new FormMessage();
                s_mainForm = new Form1();
                Application.Run(s_mainForm);
            }
            catch (Exception e)
            {
            }
}
.
.
.
        public static FormMessage s_formShutdownMsg = null; //somewhere in the project
