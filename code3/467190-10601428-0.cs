    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        if (MessageBox.Show("Contiue or not", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.No)
            Application.Exit();
        else
        {
            Application.Run(new Form1());
        }
    }
