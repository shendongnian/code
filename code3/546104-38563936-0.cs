    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace NonBlockingSerialPortReadLine
    {
        public partial class Form1 : Form
        {
        System.IO.Ports.SerialPort sp = new System.IO.Ports.SerialPort();
        public event EventHandler OnNewLineReceived;
        System.Windows.Forms.Timer NewDataTimer = new System.Windows.Forms.Timer();
        int StateMachine = 0;
        StringBuilder stringBuffer = new StringBuilder();
        public Form1()
        {
            InitializeComponent();
            InitTimer();
            InitOnNewLineReceived();
        }
        private void InitTimer()
        {
            NewDataTimer.Interval = 50;
            NewDataTimer.Tick += NewDataTimer_Tick;
        }
        private void InitOnNewLineReceived()
        {
            OnNewLineReceived += Form1_OnNewLineReceived;
        }
        void Form1_OnNewLineReceived(object sender, EventArgs e)
        {
            SerialStringMessgae STM = e as SerialStringMessgae;
            string messgae = STM.message;
            // PARSE YOU MESSAGE HERE - the debug line below is not mandatory
            
            System.Diagnostics.Debug.WriteLine(messgae);
        }
        class SerialStringMessgae : EventArgs
        {
            public string message;
        }
        private void StartListeningButton_Click(object sender, EventArgs e)
        {
            StartListeningButton.Enabled = false;
            sp = new System.IO.Ports.SerialPort("COM4",57600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
            try
            {
                sp.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            if (sp.IsOpen)
            {
                NewDataTimer.Enabled = true;
            }
        }
        void NewDataTimer_Tick(object sender, EventArgs e)
        {
            string newData = sp.ReadExisting();
            foreach (char c in newData)
            {
                switch (StateMachine)
                {
                    case 0:
                        // waiting for '\r'
                        if (c == '\r')
                        {
                            StateMachine = 1;
                        }
                        else
                        {
                            stringBuffer.Append(c);
                        }
                        break;
                    case 1:
                        // waiting for '\n'
                        if (c == '\n')
                        {
                            if (OnNewLineReceived != null)
                            {
                                SerialStringMessgae STM = new SerialStringMessgae();
                                STM.message = stringBuffer.ToString();
                                OnNewLineReceived(this, STM);
                            }
                        }
                        // after parsing the message we reset the state machine
                        stringBuffer = new StringBuilder();
                        StateMachine = 0;
                        break;
                }
            }
        }
    }
    }
