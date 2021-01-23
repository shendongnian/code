    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        using(var loginForm = new Login())
             if (loginForm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                 return;
        Application.Run(new Main_Usr()); // change main form
    }
