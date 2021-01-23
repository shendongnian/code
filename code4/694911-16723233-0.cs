    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = (1000);
            timer1.Enabled = false;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Interval = (1000);
            timer2.Enabled = false;
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            timer1.Start();
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }
        private void LogWrite(string txt)
        {
            textBoxCombatLog.AppendText(txt + Environment.NewLine);
            textBoxCombatLog.SelectionStart = textBoxCombatLog.Text.Length;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            LogWrite(TimeDate + "player hit");
            timer2.Start();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            LogWrite(TimeDate + "mob hit");
            timer1.Start();
        }
        private string TimeDate
        {
            get { return DateTime.Now.ToString("HH:mm:ss") + ": "; }
        }
    }
