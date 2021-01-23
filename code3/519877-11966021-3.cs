    using System;
    using System.Collections;
    using System.Windows.Forms;
    using System.Diagnostics;
    
    namespace testprocessapp
    {
        public partial class Form1 : Form
        {
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                Process[] p = Process.GetProcesses();
                timer1.Interval = 10000;
    
                checkedListBox1.Items.Clear();
    
                foreach (Process plist in p)
                {
                    checkedListBox1.Items.Add(plist.ProcessName);
                }
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                int counter = 0;
    
                Process[] p = Process.GetProcesses();
    
                foreach (Process process in p)
                {
                    foreach (var item in checkedListBox1.Items)
                    {
                        if (item.ToString() == process.ProcessName)
                        {
                            counter = counter + 1;
                        }
                    }
                }
    
                MessageBox.Show(counter == 0 ? "Your process has been terminated" : "Your process is still there");
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                ArrayList arrayList = new ArrayList();
    
                foreach (var checkedItem in checkedListBox1.CheckedItems)
                {
                    arrayList.Add(checkedItem);
                }
    
                checkedListBox1.DataSource = arrayList;
    
                //button1.Enabled = false;
                button1.Text = "Monitoring...";
    
                timer1.Start();
    
                
            }
        }
    }
