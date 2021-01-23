        using System;
        using System.IO.Ports;         
        using System.Windows.Forms;
        namespace ComPortTests
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
