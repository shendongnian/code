    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Threading;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
    	public Form1()
    	{
    	    InitializeComponent();
    	}
    
    	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    	{
    	    startServer() // Call here what you want to execute in another thread
    	}
        }
    
    }
