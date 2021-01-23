    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    
    
    namespace WindowsFormsApplication1
    {
        private int counter;
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
    
            Process[] p = Process.GetProcesses();
    
            private void Form1_Load(object sender, EventArgs e)
            {
                timer1.Interval = 1000;
    
    // This part gets all of the processes and adds them to the checklistbox
    //-----------------------------------------------------------------------
                foreach (Process plist in p)
                {
                    checkedListBox1.Items.Add(plist.ProcessName);
                }
    //------------------------------------------------------------------
    
            }
    
    // I tried to make a timer that would regather all the processes again and
    // compare the processes from the checkedlistbox1.checkedItems.
    //-----------------------------------------------------------------------
            private void timer1_Tick(object sender, EventArgs e)
            {
                counter = 0;
                Process p2 = Process.GetCurrentProcess();
    
                foreach (var pl in checkedListBox1.CheckedItems)
                {
                    counter = counter + 1;
                }
                if(counter ==0)
                {
                   DhutDownMethod();
                }
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                timer1.Start();
            }
            private void ShutDownMethod()
            {
               //Do shut down code here...   
            }
    
        }
    }
