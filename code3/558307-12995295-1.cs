    namespace WindowsTest
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Connect connect;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            connect = new Connect();
            connect.ProgressChanged += new ProgressChangedEventHandler(connect_ProgressChanged);
            connect.WorkComplete += new Connect.WorkCompleteEventHandler(connect_WorkComplete);
            connect.BeginLongRunningProcess();
        }
        private void connect_WorkComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = string.Format("Status: {0}", "User Cancelled!");
                return;
            }
            if (e.Error != null)
            { 
                //Process exception       
                lblStatus.Text = string.Format("Status: {0}", "Error!");
                lblStatus.ForeColor = Color.Red;
                return;
            }
            lblStatus.Text = string.Format("Status: Complete. {0}", e.Result);
        }
        private void connect_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblStatus.Text = string.Format("Status: {0}", e.UserState.ToString());
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (connect != null)
            {
                connect.Cancel();
            }
        }        
    }
    }
