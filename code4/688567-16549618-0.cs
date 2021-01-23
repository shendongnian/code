    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            DateTime newDate = new DateTime(2013, 1, 1);
            public Form1()
            {
                InitializeComponent();
                AddTime(); // call the method, otherwise timer will not start 
            }
            void AddTime()
            {
                timer1.Interval = 60000; // every minute (1 minute = 60000 milliseconds)
                timer1.Enabled = true;
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Start();
            }
            void timer1_Tick(object sender, EventArgs e)
            {
                newDate = newDate.AddMonths(3); 
                label1.Text = newDate.ToString();
            }
        }
    }
