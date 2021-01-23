    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    namespace thread_example
    {
    public partial class Form1 : Form
    {
        private int i = 0;
        public Thread Run_thread = null, run1 = null; // thread definition
        public static AutoResetEvent myResetEvent = new AutoResetEvent(false);//intially set to false..
        public Form1()
        {
            InitializeComponent();
            run1 = new Thread(new ThreadStart(run_tab));
            run1.IsBackground = true;
            run1.Start();
        }
        private void run_tab()
        {
            //do something.        
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            form2 f2 = new form2();
            f2.Show();
        }
    }
    }
    // Form 2 code...
   
      namespace thread_example
      {
        public partial class form2 : Form
      {
        public form2()
        {
            InitializeComponent();
        }
        private void btn_stop_Click(object sender, EventArgs e)
        {
            Form1.myResetEvent.WaitOne();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1.myResetEvent.Set();
        }
     }
    }
