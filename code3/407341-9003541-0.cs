        public partial class Form1 : Form
        {
        	public Form1()
        	{
        		InitializeComponent();
        	}
        
        	private void button1_Click(object sender, EventArgs e)
        	{
        		// Disables UI elements using the panel
        		this.SetPanelEnabledProperty(false);
        
        		// Starts the background work
        		System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(this.Worker));
        	}
        
        	private void Worker(object state)
        	{
        		// Simulates some work
        		System.Threading.Thread.Sleep(2000);
        
        		// Now the work is done, enable the panel
        		this.SetPanelEnabledProperty(true);
        	}
        
        	private void SetPanelEnabledProperty(bool isEnabled)
        	{
        		// InvokeRequired is used to manage the case the UI is modified
        		// from another thread that the UI thread
        		if (this.panel1.InvokeRequired)
        		{
        			this.panel1.Invoke(new MethodInvoker(() => this.SetPanelEnabledProperty(isEnabled)));
        		}
        		else
        		{
        			this.panel1.Enabled = isEnabled;
        		}
        	}
        }
