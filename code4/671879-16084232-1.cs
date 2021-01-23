        static Label bla = new Label()
        {
            Text = "Mama Mia, Gestione Cartelle!",
            Left = 100,
            Top = 100,
            Width=300
        };
        static Label hangOn = new Label()
        {
            Text="Hang loose"
        };
        static Form mainForm = new Form()
        {
            Width = 600,
            Height = 600
        };
    [STAThread]
    static void Main(string[] args)
    {
        mainForm.Controls.Add(bla);
        mainForm.Controls.Add(hangOn);
        mainForm.MouseMove += (o, e) => { hangOn.Left = e.X; hangOn.Top = e.Y; };
        Debug.WriteLine("UI Thread: "+ Thread.CurrentThread.ManagedThreadId);
        TaskGestioneCartelle();
        Application.Run(mainForm);
    }
