    public partial class Form1 : Form
    {
        private BackgroundWorker backgroundWorker1;
        private testClass t1 = new testClass();
        public Form1()
        {
            InitializeComponent();
         
            // subscribe to your event
            t1.OnProgressUpdate += t1_OnProgressUpdate;
        }
        private void t1_OnProgressUpdate(int value)
        {
            // Its another thread so invoke back to UI thread
            base.Invoke((Action)delegate
            {
                label1.Text += Convert.ToString(value);
            });
        }
      
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            t1.changevalue(1000);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
    }
    class testClass
    {
        public delegate void ProgressUpdate(int value);
        public event ProgressUpdate OnProgressUpdate;
        private int val;
        public int changevalue(int i)
        {
            for (int j = 0; j < 1000; j++)
            {
                val += i + j;
                // Fire the event
                if (OnProgressUpdate != null)
                {
                    OnProgressUpdate(i);
                }
            }
            return val;
        }
    } 
