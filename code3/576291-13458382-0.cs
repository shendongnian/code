    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Net.NetworkInformation;
    using System.ServiceProcess;
    using System.Threading;
    using System.ComponentModel;
    
    
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
    
            private Ping pingClass;
            public Form1()
            {
                InitializeComponent();
                pingClass = new Ping();
            }
    
            public void Form1_Load(object sender, EventArgs e)
            {
                timer1.Interval = 1000;
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Start();
    
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                //MessageBox.Show("Timeout!");
                RefreshPing();
    
            }
    
            private void RefreshPing()
            {
                PingReply pingReply = pingClass.Send("10.209.123.123");
                label4.Text = (pingReply.RoundtripTime.ToString());
                //+ "ms");
                label5.Text = (pingReply.Status.ToString());
    
    
    
                if (Convert.ToInt32(label4.Text) > 0 && Convert.ToInt32(label4.Text) < 100)
                    this.pictureBox1.Load("greenLAT.png");
    
                if (Convert.ToInt32(label4.Text) > 100 && Convert.ToInt32(label4.Text) < 200)
                    this.pictureBox1.Load("yellowLAT.png");
    
                if (Convert.ToInt32(label4.Text) > 200 && Convert.ToInt32(label4.Text) < 1000)
                    this.pictureBox1.Load("redLAT.png");
    
                ToolTip tt = new ToolTip();
                tt.SetToolTip(this.pictureBox1, "Your current network delay is " + label4.Text + "ms");
                Refresh();
            }
    
        }
    }
