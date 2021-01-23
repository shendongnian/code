    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateControls(false);
            bgwLoadFile.DoWork += new DoWorkEventHandler(bgwLoadFile_DoWork);
            bgwLoadFile.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwLoadFile_RunWorkerCompleted);
        }
        private void buttonUpload_Click(object sender, EventArgs e)
        {
            UpdateControls(true);
            bgwLoadFile.RunWorkerAsync();
        }
        void bgwLoadFile_DoWork(object sender, DoWorkEventArgs e)
        {
            //simulate work
            System.Threading.Thread.Sleep(2000);
        }
        void bgwLoadFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(!e.Cancelled && e.Error == null)
                UpdateControls(false);
        }
        private void UpdateControls(bool isVisable)
        {
            if (isVisable)
            {
                pictureBox1.BringToFront();
                picLoading.BringToFront();
                label1.BringToFront();
            }
            else
            {
                pictureBox1.SendToBack();
                picLoading.SendToBack();
                label1.SendToBack();
            }
        }
    }
