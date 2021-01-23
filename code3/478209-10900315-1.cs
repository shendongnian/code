    using System;
    using System.Windows.Forms;
    
    namespace MouseHoverDelay
    {
    	public partial class Form1 : Form
    	{
    		public Form1()
    		{
    			InitializeComponent();
    		}
    
    		// triggers when Delay milliseconds have passed since hovering mouse over control
    		protected void timer_Elapsed(object o, EventArgs e)
    		{
    			MessageBox.Show("Hovered for 2 seconds!");
    		}
    	}
    }
