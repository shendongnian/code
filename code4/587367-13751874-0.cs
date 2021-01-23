    public static void ThreadProc<TForm>() where TForm : Form, new()
    {
        System.Windows.Forms.Application.Run(new TForm());
    }
    new System.Threading.Thread(() => ThreadProc<MainForm>())
