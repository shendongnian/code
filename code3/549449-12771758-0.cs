    public partial class Form1 : Form, IView
        {
            MyPresenter p ;
    
            public Form1()
            {
                InitializeComponent();
                p = new MyPresenter(this);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (p.IsBusy())
                {
                    return;
                }
                p.StartTimeConsumingJob();
            }
    
            public void ShowProgress(int progressPercentage)
            {
                if (progressBar1.InvokeRequired)
                    progressBar1.Invoke(new MethodInvoker(delegate { progressBar1.Value = progressPercentage; }));
                else
                    progressBar1.Value = progressPercentage;
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                p.Cancel();
            }
             
        }
