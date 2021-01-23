    namespace read_display_data
{
    public partial class Form1 : Form
    {
        SerialPort port = new SerialPort("COM1", 19200, Parity.None, 8, StopBits.One);
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            port.Open();
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }
        private void Sendbutton_Click(object sender, EventArgs e)
        {
            port.Write(new byte[] { 0x55, 0x08, 0x00, 0x00, 0x00, 0x00, 0x03, 0x5D }, 0, 8)
            byte[] buffer1 = new byte[] { 0x55, 0x08, 0x00, 0x00, 0x00, 0x00, 0x03, 0x5D };
            Log1(LogMsgType.Outgoing, DateTime.Now + "  --  " + ByteArrayToHexString(buffer1) + "\n");
        }
        public enum LogMsgType { Incoming, Outgoing, Normal };
        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = port.BytesToRead;
            byte[] buffer = new byte[bytes];
            port.Read(buffer, 0, bytes);
            Thread.Sleep(100);
            Log(LogMsgType.Incoming, DateTime.Now + "  --  " + ByteArrayToHexString(buffer) + "\n");
            Log2(LogMsgType.Incoming, DateTime.Now + "  --  " + GetInBinaryString(buffer) + "\n");
           
        }
        private string ByteArrayToHexString(byte[] buffer)
        {
            StringBuilder sb = new StringBuilder(buffer.Length * 3);
            foreach (byte b in buffer)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }
        private string GetInBinaryString(byte[] buffer)
        {
            StringBuilder sb = new StringBuilder(buffer.Length * 8);
            foreach (byte b in buffer)
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0').PadRight(5, ' '));
            return sb.ToString().ToUpper();
        }
        private void Log(LogMsgType msgtype, string msg)
        {
            textBox1.Invoke(new EventHandler(delegate
            {
                textBox1.SelectedText = string.Empty;
                textBox1.AppendText(msg);
                textBox1.ScrollToCaret();
            }
            ));
        }
        private void Log1(LogMsgType msgtype, string msg)
        {
            textBox2.Invoke(new EventHandler(delegate
            {
                textBox2.SelectedText = string.Empty;
                textBox2.AppendText(msg);
                textBox2.ScrollToCaret();
            }
            ));
        }
        private void Log2(LogMsgType msgtype, string msg)
        {
            textBox3.Invoke(new EventHandler(delegate
            {
                textBox3.SelectedText = string.Empty;
                textBox3.AppendText(msg);
                textBox3.ScrollToCaret();
            }
            ));
        }
