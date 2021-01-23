    using System;
    using System.IO.Ports;          //<-- necessary to use "SerialPort"
    using System.Windows.Forms;
    
    namespace ComPortTests
    {
        public partial class Form1 : Form
        {
            private SerialPort _serialPort;         //<-- declares a SerialPort Variable to be used throughout the form
            private const int BaudRate = 9600;      //<-- BaudRate Constant. 9600 seems to be the scale-units default value
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                string[] portNames = SerialPort.GetPortNames();     //<-- Reads all available comPorts
                foreach (var portName in portNames)
                {
                    comboBox1.Items.Add(portName);                  //<-- Adds Ports to combobox
                }
                comboBox1.SelectedIndex = 0;                        //<-- Selects first entry (convenience purposes)
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                //<-- This block ensures that no exceptions happen
                if(_serialPort != null && _serialPort.IsOpen)
                    _serialPort.Close();
                if (_serialPort != null)
                    _serialPort.Dispose();
                //<-- End of Block
    
                _serialPort = new SerialPort(comboBox1.Text, BaudRate, Parity.None, 8, StopBits.One);       //<-- Creates new SerialPort using the name selected in the combobox
                _serialPort.DataReceived += SerialPortOnDataReceived;       //<-- this event happens everytime when new data is received by the ComPort
                _serialPort.Open();     //<-- make the comport listen
                textBox1.Text = "Listening on " + _serialPort.PortName + "...\r\n";
            }
    
            private delegate void Closure();
            private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
            {
                if (InvokeRequired)     //<-- Makes sure the function is invoked to work properly in the UI-Thread
                    BeginInvoke(new Closure(() => { SerialPortOnDataReceived(sender, serialDataReceivedEventArgs); }));     //<-- Function invokes itself
                else
                {
                    while (_serialPort.BytesToRead > 0) //<-- repeats until the In-Buffer is empty
                    {
                        textBox1.Text += string.Format("{0:X2} ", _serialPort.ReadByte());
                            //<-- bytewise adds inbuffer to textbox
                    }
                }
            }
        }
    }
