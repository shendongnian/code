    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Form mainForm = new MyForm();
        // Initialize the service.
        MyService service = new MyService(mainForm);
        Application.Run(mainForm);
    }
    public class MyService
    {
        public event EventHandler MyEvent;
        private readonly ISynchronizeInvoke synchronizeInvoke;
        public MyService(ISynchronizeInvoke synchronizeInvoke)
        {
            this.synchronizeInvoke = synchronizeInvoke;
        }
        private void OnMyEvent()
        {
            if (MyEvent != null)
            {
                if (synchronizeInvoke.InvokeRequired)
                {
                    synchronizeInvoke.BeginInvoke(new Action(() => MyEvent(this, EventArgs.Empty)), null);
                }
            }
        }
    }
