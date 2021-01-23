        public partial class Form2 : Form
        {
            MyBackgroundWorker backgroundWorker1 = null;
            Dictionary<string, string> dct = new Dictionary<string, string>();
            public Form2()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
            }
            private void btnStart_Click(object sender, EventArgs e)
            {
                backgroundWorker1 = new MyBackgroundWorker();
                backgroundWorker1.WorkerReportsProgress = true;
                backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
                backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
                backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
                backgroundWorker1.RunWorkerAsync(int.Parse(txtNumber.Text));
            }
            private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
                string strID = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("hhmmss") + DateTime.Now.Millisecond.ToString();
                MyBackgroundWorker tmpBg = (sender as MyBackgroundWorker);
                tmpBg.Name = "bg_" + strID;
                ProgressBar pb = new ProgressBar();
                pb.Minimum = 0;
                pb.Maximum = 100;
                pb.Name = "pb_" + strID;
                pb.Width = txtNumber.Width;
                this.BeginInvoke((MethodInvoker)delegate
                {
                    flowLayoutPanel1.Controls.Add(pb);
                });
                dct.Add(tmpBg.Name, pb.Name);
                int input = (int)e.Argument;
                for (int i = 1; i <= input; i++)
                {
                    Console.WriteLine(tmpBg.Name + ": " + (i * 100 / input));   //for testing (this line slows the program down a lot)
                    tmpBg.ReportProgress(i * 100 / input);
                    if (tmpBg.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
            // This event handler updates the progress bar. 
            private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                MyBackgroundWorker tmpBg = (sender as MyBackgroundWorker);
                string strName = tmpBg.Name.Substring(3);
                ProgressBar pb;
                if (!string.IsNullOrEmpty(strName))
                {
                    foreach (Control c in flowLayoutPanel1.Controls)
                    {
                        if (c.Name == ("pb_" + strName))
                        {
                            pb = (ProgressBar)c;
                            pb.Value = Math.Min(100,e.ProgressPercentage);
                        }
                    }
                }
            }
            private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                MyBackgroundWorker tmpBg = (sender as MyBackgroundWorker);
                string strName = tmpBg.Name;
                strName = strName.Substring(3);
                ProgressBar pb = (ProgressBar)this.flowLayoutPanel1.Controls.Find(("pb_" + strName), true)[0];
                pb.Value = 100;
                //MessageBox.Show("Done");
            }
        }
        public class MyBackgroundWorker : System.ComponentModel.BackgroundWorker
        {
            public MyBackgroundWorker()
            {
            }
            public MyBackgroundWorker(string name)
            {
                Name = name;
            }
            public string Name { get; set; }
        }
