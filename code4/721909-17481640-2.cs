    public partial class Form1 : Form
    {
        SerialPort serialPort = new SerialPort();
        public Form1()
        {
            InitializeComponent();
            serialPort.PortName = "Com1";
            serialPort.BaudRate = 115200;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataRecievedHandler);
            openSerial();
        }
        void DataRecievedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            MessageBox.Show(indata);
            closeSerial();
        }
        public void openSerial()
        {
            if (!serialPort.IsOpen) serialPort.Open();
        }
        public void closeSerial()
        {
            if (serialPort.IsOpen) serialPort.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openSerial();
            serialPort.Write("Hello");
        }
    }
 
