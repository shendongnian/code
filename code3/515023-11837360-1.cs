    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class Form1 : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    
        DateTime lastSnmpTime;
        TimeSpan snmpTime = TimeSpan.FromSeconds(30);
        DateTime startTime;
        TextBox elapsedTimeTextBox;
        Timer timer;
    
        public Form1()
        {
            timer = new Timer { Enabled = false, Interval = 10 };
            timer.Tick += new EventHandler(timer_Tick);
    
            elapsedTimeTextBox = new TextBox { Location = new Point(10, 10), ReadOnly = true };
            Controls.Add(elapsedTimeTextBox);
        }
    
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
    
            startTime = DateTime.Now;
            timer.Start();
        }
    
        void timer_Tick(object sender, EventArgs e)
        {
            // Update elapsed time
            elapsedTimeTextBox.Text = (DateTime.Now - startTime).ToString("g");
    
            // Send SNMP
            if (DateTime.Now - lastSnmpTime >= snmpTime)
            {
                lastSnmpTime = DateTime.Now;
    
                // Do SNMP
    
                // Adjust snmpTime as needed
            }
        }
    }
