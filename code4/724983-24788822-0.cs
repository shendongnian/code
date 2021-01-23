    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO.Ports;
    namespace SMSget
    {
    public partial class SMSLogPanel : UserControl
    {
        SerialPort sp;
        int datab = 0;
        bool dtr = false;
        bool encod;
        Handshake h;
        Parity p;
        int wtimeout = 0;
        StopBits s;
        #region default constructor
        public SMSLogPanel()
        {
            InitializeComponent();
            this.sp = serialPort1 = new SerialPort();
            this.datab = serialPort1.DataBits = 8;
            this.dtr = serialPort1.DtrEnable = true;
            this.encod = serialPort1.Encoding.Equals("iso-8859-1");
            this.h = serialPort1.Handshake = Handshake.RequestToSend;
            this.p = serialPort1.Parity = Parity.None;
            this.wtimeout = serialPort1.WriteTimeout = 300;
            this.s = serialPort1.StopBits = StopBits.One;
            checkLink();
        }
        #endregion
        #region checking communication and setting user controls...
        private void checkLink()
        {
            GetValues value = new GetValues();
            string com = value.getPort();
            int baud = value.getBaud();
            int timeot = value.getTimeout();
            serialPort1.PortName = com;
            serialPort1.BaudRate = baud;
            serialPort1.ReadTimeout = timeot;
            serialPort1.Open();
            if (serialPort1.IsOpen)
            {
                label1.Visible = true;
            }
            else
            {
                 MessageBox.Show("Komunikacija sa modemom se ne može uspostaviti, molimo postavite novu konfiguraciju...!");
                this.Controls.Clear();
                SMSConfigPanel cfg = new SMSConfigPanel();
                cfg.Show();
                this.Controls.Add(cfg);
            }
            serialPort1.Close();
        }
        #endregion
        #region panel load method
        private void SMSLogPanel_Load(object sender, EventArgs e)
        {
            setGSM();
        }
        #endregion
        #region execute serialport handler
        public void getMessage()
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(getResponse);
            }
            else
            {
                MessageBox.Show("Nije moguće zaprimiti poruku, komunikacijski port nije otvoren...1");
                return;
            }
        }
        #endregion
        #region get response from modem
        public void getResponse(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serPort = (SerialPort)sender;
            string input = serPort.ReadExisting();
       
            if (input.Contains("+CMT:"))
            {
                
                if (input.Contains("AT+CMGF=1"))
                {
                    string[] message = input.Split(Environment.NewLine.ToCharArray()).Skip(7).ToArray();
                    textBox1.Text = string.Join(Environment.NewLine, message);
                }
                this.Invoke((MethodInvoker)delegate
                {
                    textBox1.Text = input;
                });
            }
            else
            {
                return;
            }
        }
        #endregion
        #region initialize GSM
        private void setGSM()
        {
            serialPort1.Open();
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("Problem u komunikaciji sa modemom, port nije otvoren...!");
            }
            serialPort1.Write("AT+CMGF=1" + (char)(13));
            serialPort1.Write("AT+CNMI=1,2,0,0,0" + (char)(13));
        }
        #endregion
        #region setiranje timer-a...
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer1.Stop();
            getMessage();
            timer1.Start();
        }
        #endregion
    }
         
    }
