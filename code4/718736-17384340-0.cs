    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread T = new System.Threading.Thread(new System.Threading.ThreadStart(RUN));
            T.Start();
        }
        private void RUN()
        {
            // control created in a different thread:
            System.Windows.Forms.Label l = new System.Windows.Forms.Label();
            l.Location = new System.Drawing.Point(12, 10);
            l.Text = "Some Text";
            // control added in the main UI thread:
            if (tabControl1.TabPages[0].InvokeRequired)
            {
                tabControl1.TabPages[0].BeginInvoke((MethodInvoker)delegate()
                {        
                    tabControl1.TabPages[0].Controls.Add(l);
                });
            }
        }
    }
