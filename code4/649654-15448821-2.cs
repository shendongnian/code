    public partial class SMSapplication : Form
    {
        private SynchronizationContext context = null;
        private SerialPort port;
        public SMSapplication()
        {
            InitializeComponent();
            this.countSMSok.Text = "0";
            this.context = WindowsFormsSynchronizationContext.Current;
        }
        public void updateCountSMS(String label)
        {
            this.context.Post(new SendOrPostCallback(updateCountSMSSync), label);
        }
        private void updateCountSMSSync(object o)
        {
            string label = o as string;
            int num;
            if (label == this.countSMSok.Name.ToString())
            {
                if (int.TryParse(this.countSMSok.Text.ToString(), out num))
                {
                    this.countSMSok.Text = (++num).ToString();
                }
            }
        }
        private void btnRequestStart_Click(object sender, EventArgs e)
        {
            clsWorker objclsWorker = new clsWorker(this, this.port, this.urlChecker.Text);
            objclsWorker.StartThread();
        }
    }
