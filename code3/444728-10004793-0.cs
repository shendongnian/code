    namespace AsyncForm
    {
        public partial class Form1 : Form
        {
    
            private List<String> collectionItems = new List<String>();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
                for (int i = 0; i < 20; i++)
                {
                    ((List<String>)e.Argument).Add("Something " + i);
                    System.Threading.Thread.Sleep(200);
                }
            }
    
            private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                listBox1.Items.AddRange(collectionItems.ToArray());
                listBox1.Visible = true;
                pictureBox1.Visible = false;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                backgroundWorker1.RunWorkerAsync(collectionItems);
            }
        }
    }
