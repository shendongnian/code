    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
    	public class ToolStripEx : ToolStrip
    	{
    		protected override void OnLocationChanged(EventArgs e)
    		{
    			if (this.Parent is ToolStripPanel)
    			{
    				ToolStripPanel parent = this.Parent as ToolStripPanel;
    
    				if (parent.Orientation == Orientation.Horizontal)
    				{
    					if (this.Location.Y != 0)
    					{
    						this.Location = new Point(this.Location.X, 0);
    						return;
    					}
    				}
    				else if (parent.Orientation == Orientation.Vertical)
    				{
    					if (this.Location.X != 0)
    					{
    						this.Location = new Point(0, this.Location.Y);
    						return;
    					}
    				}
    			}
    			base.OnLocationChanged(e);
    		}
    	}
    }
