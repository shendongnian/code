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
    			this.toolStripContainer1.LeftToolStripPanel.MaximumSize = new Size(toolStripEx1.Height, 0);
    			this.toolStripContainer1.BottomToolStripPanel.MaximumSize = new Size(0, toolStripEx1.Height);
    			this.toolStripContainer1.RightToolStripPanel.MaximumSize = new Size(toolStripEx1.Height, 0);
    		}
    	}
    }
