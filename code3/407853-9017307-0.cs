    public partial class Form1 : Form
    {
    	private Worker worker;
    
    	public Form1()
    	{
    		InitializeComponent();
    	}
    
    	private void button1_Click(object sender, EventArgs e)
    	{
    		worker = new Worker();
    		worker.ProgressUpdated += this.worker_ProgressUpdated;
    		worker.WorkDone += this.worker_WorkDone;
    		worker.Start();
    	}
    
    	private void worker_WorkDone(object sender, EventArgs e)
    	{
    		// Detaches event handlers
    		// /!\ Will be called from a thread different than the UI thread
    		worker.ProgressUpdated -= this.worker_ProgressUpdated;
    		worker.WorkDone -= this.worker_WorkDone;
    	}
    
    	private void worker_ProgressUpdated(object sender, ProgressEventArgs e)
    	{
    		// Updates the UI
    		// /!\ Will be called from a thread different than the UI thread
    		this.SetLabelText(string.Format("Percentage: {0}", ((double)e.Value * 100 / (e.Max - e.Min))));
    	}
    
    	private void SetLabelText(string text)
    	{
    		// Following required if the method is called from a thread that is not the UI thread
    		if (this.label1.InvokeRequired)
    		{
    			this.label1.Invoke(new MethodInvoker(() => this.SetLabelText(text)));
    		}
    		else
    		{
    			this.label1.Text = text;
    		}
    	}
    }
