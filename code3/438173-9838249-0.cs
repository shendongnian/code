    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication4 {
        public partial class Form1 : Form {
            private readonly BackgroundWorker bg = new BackgroundWorker();
            public Form1() {
                InitializeComponent();
                bg.DoWork += doWork;
            }
            private void doWork(object sender, DoWorkEventArgs e) {
                for (int i = 0; i < 15; i++) {
                    LogBoxTextAdd("TEST");
                }
            }
            private void LogBoxTextAdd(string varText) {
                if (InvokeRequired) {
                    textBox1.Invoke(new MethodInvoker(() => LogBoxTextAdd(varText)));
                } else {
                    textBox1.Text = varText + "\r\n" + textBox1.Text;
                }
            }
            private void button1_Click(object sender, EventArgs e) {
                bg.RunWorkerAsync();
            }
        }
    }
