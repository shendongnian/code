    using System;
    using System.IO;
    using System.IO.Ports;
    namespace comport
    {
        public partial class Form1 : Form
        
        {
            public Form1()
            
            {
                
                InitializeComponent();
            }
            
            private SerialPort _serialPort = null;
            
            private void Form1_Load(object sender, EventArgs e)
            {
                AppConfiguration.sConfigType = "default";
                
                _serialPort = new SerialPort("COM1", 9600, Parity.None, 8);
                
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
                
                _serialPort.Open();
                
            }
            
            void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                string data = _serialPort.ReadExisting();
                
                textBox2.Text = data;
            }
        }
            
    }
