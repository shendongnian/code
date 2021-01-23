    public partial class Form1 : Form
    {
    	public Form1()
    	{
    		InitializeComponent();
    	}
    
    	private void button1_Click(object sender, EventArgs e)
    	{
    		BackgroundWorker bg = new BackgroundWorker();
    		bg.DoWork += new DoWorkEventHandler(bg_DoWork);
    		bg.RunWorkerAsync();
    	}
    
    	void bg_DoWork(object sender, DoWorkEventArgs e)
    	{
    		for (int i = 0; i < 1000000000; i++)
    		{
    			Action action = () => richTextBox1.Text += "Line Number " + i;
    			richTextBox1.Invoke(action); 
    		}
    	}
    }
