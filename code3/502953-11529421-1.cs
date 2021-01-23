    [STAThread]
    static void Main()
    {
        using(new Strategy())
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public class Strategy : IDisposable
    {
        public void Dispose()
        {
            WriteLogs()
        }
        ...
    }
