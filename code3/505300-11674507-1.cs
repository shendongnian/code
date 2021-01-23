    namespace Scope_Project_Ver_2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();            
                // *** Output data timer ***
                otimer.Interval = 50;
                // otimer.Interval = isendFreq;
                otimer.Tick += new EventHandler(otimer_Tick);
                // *** Input data timer ***
                // itimer.Interval = 601;                        <- to be unchecked
                // itimer.Tick += new EventHandler(itimer_Tick); <- to be unchecked
            }
    
            public int b1,b2,b3,b4,b5;
            public string sb1, sb2, sb3, sb4, sb5;
            public int ivorSpeed;
            public string svorSpeed;
            public int ihorSpeed;
            public string shorSpeed;
            public int isendFreq;
           
    
            private void sendDataB_Click(object sender, MouseEventArgs e)
            {
                if (sendDataCB.Checked)
                {
                    sendDataCB.Checked = false;
                    if (otimer.Enabled)
                        otimer.Stop();
                }
                else
                {
                    sendDataCB.Checked = true;
                    if (!otimer.Enabled)
                        otimer.Start();
                }
            }
    
            
            void otimer_Tick(object sender, EventArgs e)
            {
                SerialPort port = new SerialPort(
                "COM1", 9600, Parity.None, 8, StopBits.One);
                port.Open();
                port.Write("Q"); //                         Q
                port.Write(sb1); //                         1
                port.Write(sb2); //                         2
                // Binary stuff  // Ver Speed Binary        3           
                byte[] bverbinary = new byte[1];
                byte verbinary = 0;
                verbinary = Byte.Parse(svorSpeed);
                bverbinary[0] = verbinary;
                port.Write(bverbinary, 0, bverbinary.Length);
                // End of Binary stuff for Ver Speed
                // Binary stuff // Hor Speed Binary         4
                byte[] bhorbinary = new byte[1];
                byte horbinary = 0;
                horbinary = Byte.Parse(shorSpeed);
                bhorbinary[0] = horbinary;
                port.Write(bhorbinary, 0, bhorbinary.Length);
                port.Write(sb5);  // Movement               5
                port.Close();
            }
    
    
            private void vorSpeed_ValueChanged(object sender, EventArgs e)
            {
                // MessageBox.Show((this.vorSpeed.Value).ToString());
                this.Text = "You changed the Vertical Speed to " + vorSpeed.Value;
                ivorSpeed = (int)vorSpeed.Value;
                svorSpeed = ivorSpeed.ToString(); 
            }
    
            private void horSpeed_ValueChanged(object sender, EventArgs e)
            {
                // MessageBox.Show((this.horSpeed.Value).ToString());
                this.Text = "You changed the Horizontal Speed to " + horSpeed.Value;
                ihorSpeed = (int)horSpeed.Value;
                shorSpeed = ihorSpeed.ToString(); 
            }
    
            private void scopeUp_MouseDown(object sender, MouseEventArgs e) // Scope Up On
            {
                b1 = 2;
                b2 = 0;
                b5 = 1;
                sb1 = b1.ToString();
                sb2 = b2.ToString();
                sb3 = b3.ToString();
                sb4 = b4.ToString();
                sb5 = b5.ToString();
            }
    
            private void scopeUp_MouseUp(object sender, MouseEventArgs e) // Scope Up Off
            {
                
            }
    
            private void scopeRight_MouseDown(object sender, MouseEventArgs e)
            {
                b1 = 1;
                b2 = 2;
                b5 = 1;
                sb1 = b1.ToString();
                sb2 = b2.ToString();
                sb3 = b3.ToString();
                sb4 = b4.ToString();
                sb5 = b5.ToString();
            }
    
            private void scopeRight_MouseUp(object sender, MouseEventArgs e)
            {
    
            }
    
            private void scopeDown_MouseDown(object sender, MouseEventArgs e)
            {
                b1 = 2;
                b2 = 1;
                b5 = 1;
                sb1 = b1.ToString();
                sb2 = b2.ToString();
                sb3 = b3.ToString();
                sb4 = b4.ToString();
                sb5 = b5.ToString();
            }
    
            private void scopeDown_MouseUp(object sender, MouseEventArgs e)
            {
    
            }
    
            private void scopeLeft_MouseDown(object sender, MouseEventArgs e)
            {
                b1 = 0;
                b2 = 2;
                b5 = 1;
                sb1 = b1.ToString();
                sb2 = b2.ToString();
                sb3 = b3.ToString();
                sb4 = b4.ToString();
                sb5 = b5.ToString();
            }
    
            private void scopeLeft_MouseUp(object sender, MouseEventArgs e)
            {
    
            }
    
            private void scopeStop_Click(object sender, EventArgs e)
            {
                b1 = 0;
                b2 = 0;
                b5 = 0;
                sb1 = b1.ToString();
                sb2 = b2.ToString();
                sb3 = b3.ToString();
                sb4 = b4.ToString();
                sb5 = b5.ToString();
            }
    
            private void sendFreq_ValueChanged(object sender, EventArgs e)
            {
                this.Text = "You changed the send Freq to " + sendFreq.Value + " m/s";
                isendFreq = (int)sendFreq.Value;
            }
        }
    }
