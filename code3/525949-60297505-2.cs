       public partial class ProgressDialog : Form
        {
            public System.Windows.Forms.ProgressBar Progressbar { get { return this.progressBar1; } }
    
            public ProgressDialog()
            {
                InitializeComponent();
            }
    
            public void RunAsync(Action action)
            {
                Task.Run(action);
            }
        }
