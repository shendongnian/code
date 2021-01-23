    using System;
    using System.Windows.Forms;
    using System.IO.Ports;
    using System.Threading;
    using System.Text;
    namespace WindowsFormsApplication1 {
        public partial class Form1 : Form {
            const int MAX_BUFFER = 100;
            int i = 0;
            byte[] DataReceived = new byte[MAX_BUFFER];
            SerialPort serialPort = new SerialPort();
            public Form1() {
                InitializeComponent();
                serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            }
            void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e) {
                // wait data ready
                Thread.Sleep(500);
                // while data ready in buffer
                while (serialPort.IsOpen && serialPort.BytesToRead > 0) {
                    // read data serial
                    DataReceived[i] = Convert.ToByte(serialPort.ReadByte());
                    // counter data
                    i++;
                    // reset conter if more then maxvalue
                    if (i >= MAX_BUFFER) {
                        i = 0;
                    }
                }
                if (i == 1 && DataReceived[0] == ASCIIEncoding.ASCII.GetBytes("^")[0]) {
                    this.textBox1.Invoke(new Action(() => {
                        this.textBox1.Text = ASCIIEncoding.ASCII.GetString(DataReceived, 0, 1);
                
                    }));
                }
            }
            public void InitSerialPort() {
                serialPort.PortName = "COM1";
                serialPort.BaudRate = 9600;
                serialPort.Parity = Parity.None;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.ReceivedBytesThreshold = 1;
            }
            private void Form1_Load(object sender, EventArgs e) {
                // initialize serial port
                InitSerialPort();
                // assure port is closed before open it
                if (serialPort != null && serialPort.IsOpen) {
                    serialPort.Close();
                }
                serialPort.Open();
            }
            private void button1_Click(object sender, EventArgs e) {
                if (serialPort.IsOpen) {
                    serialPort.Write("^");
                    // wait data sent
                    Thread.Sleep(500);
                }
            }
        }
    }
