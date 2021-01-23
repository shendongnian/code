    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
    	public partial class Form1 : Form
    	{
    		public Form1()
    		{
    			InitializeComponent();
    			this.toolStripContainer1.TopToolStripPanel.MaximumSize = new Size(0, toolStripEx1.Height);
    		}
    	}
    }
