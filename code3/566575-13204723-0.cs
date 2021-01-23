    public partial class Form1 : Form
    {
        SerialPort serialPort; 
        public Form1()
        {
            InitializeComponent();
            serialPort = new SerialPort();
            serialPort.PortName = Properties.Settings.Default.PortName;
            serialPort.BaudRate = Properties.Settings.Default.BaudRate;
            serialPort.DataBits = Properties.Settings.Default.DataBits;
            serialPort.DtrEnable = Properties.Settings.Default.DtrEnable;
            serialPort.StopBits = Properties.Settings.Default.StopBits;
            serialPort.Parity = Properties.Settings.Default.Parity;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            serialPort.PortName = "COM1";
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.PortName = serialPort.PortName;
            Properties.Settings.Default.BaudRate = serialPort.BaudRate;
            Properties.Settings.Default.DataBits = serialPort.DataBits;
            Properties.Settings.Default.DtrEnable = serialPort.DtrEnable;
            Properties.Settings.Default.StopBits = serialPort.StopBits;
            Properties.Settings.Default.Parity = serialPort.Parity;
            Properties.Settings.Default.Save(); //Saves settings 
        }
    }
