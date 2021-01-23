    public class ToolStripEx : ToolStrip
    {
    	protected override void OnLocationChanged(EventArgs e)
    	{
    		if (this.Location.Y >= this.Parent.MaximumSize.Height)
    		{
    			this.Location = new Point(this.Location.X, 0);
    		}
    		else
    		{
    			base.OnLocationChanged(e);
    		}			
    	}
    }
