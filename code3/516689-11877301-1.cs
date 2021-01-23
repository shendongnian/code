    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
    	public Form1()
    	{
    	    InitializeComponent();
    	}
    
    	private void Form1_Load(object sender, EventArgs e)
    	{
    	    // Initialize picker 
    	    dateTimePicker2.Value = Convert.ToDateTime(ObjectForValue1).AddMonths(6);
    	}
    
    	private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
    	{
    	    // Set title bar to selected date.
    	    DateTime result = dateTimePicker2.Value;
    	    this.Text = result.ToString();
    	}
        }
    }
