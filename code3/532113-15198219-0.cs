    using System;
    using System.IO.Ports;
    using System.Threading;
    using System.Windows.Forms;
    namespace CSharp_SMS
    {
      public partial class Form_SMS_Sender : Form
      {
        private SerialPort _serialPort;
        public Form_SMS_Sender()
        {
            InitializeComponent();
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            string number = textBoxNumber.Text;
            string message = textBoxMessage.Text;
            //Replace "COM7"withcorresponding port name
            _serialPort = new SerialPort("COM7", 115200);   
            Thread.Sleep(1000);
            _serialPort.Open();
            Thread.Sleep(1000);
            _serialPort.Write("AT+CMGF=1\r");
            Thread.Sleep(1000);
            _serialPort.Write("AT+CMGS=\"" + number + "\"\r\n");
            Thread.Sleep(1000);
            _serialPort.Write(message + "\x1A");
            Thread.Sleep(1000);
            labelStatus.Text = "Status: Message sent";
            _serialPort.Close();
            }
        }
    }
