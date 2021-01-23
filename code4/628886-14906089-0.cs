    namespace WindowsFormsApplication1
    {
    	public partial class Form1 : Form
    	{
    		public Form1()
    		{
    			InitializeComponent();
    		}
    
    		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    		{
    			e.KeyChar = char.ToUpper(e.KeyChar);
    		}
    	}
    }
