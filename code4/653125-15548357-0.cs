    public partial class Form1 : Form
    {
    List<int> counts = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 };
    List<long> complete = new List<long>() { 0, 0, 0, 0, 0, 0, 0, 0 };
    private void button1_Click(object sender, EventArgs e)
    {
        var backgroundWorker = new BackgroundWorker();
        backgroundWorker.DoWork += new DoWorkEventHandler(UpdateGUI);
        backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted 
        backgroundWorker.RunWorkerAsync();
        // Do stuff that updates counts and complete
        //backgroundWorker.CancelAsync();
    }
    private void UpdateGUI(object sender, EventArgs e)
    {
        
            Thread.Sleep(1000);
        
    }
    private void backgroundWorker.RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
       var backgroundWorker = sender as BackgroundWorker;
      
            label1.Text = count.ToString();
            labelF1.Text = counts[0].ToString();
            labelF2.Text = counts[1].ToString();
            labelF3.Text = counts[2].ToString();
            labelF4.Text = counts[3].ToString();
            labelF5.Text = counts[4].ToString();
            labelF6.Text = counts[5].ToString();
            labelF7.Text = counts[6].ToString();
            labelF8.Text = counts[7].ToString();
            labelC1.Text = complete[0].ToString();
            labelC2.Text = complete[1].ToString();
            labelC3.Text = complete[2].ToString();
            labelC4.Text = complete[3].ToString();
            labelC5.Text = complete[4].ToString();
            labelC6.Text = complete[5].ToString();
            labelC7.Text = complete[6].ToString();
            labelC8.Text = complete[7].ToString();
            Application.DoEvents();
        
       }
     }
