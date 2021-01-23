    public static void ThreadProc(Form form)
    {
        System.Windows.Forms.Application.Run(form);
    }
    new System.Threading.Thread(() => ThreadProc(new MainForm()))
