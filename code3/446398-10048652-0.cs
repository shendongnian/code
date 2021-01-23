   	partial class Simulator
   	{
        int oldWidth, oldWeight;
    	...
    	private void InitializeComponent()
    	{
    		... (generated initialization code)
    		this.ResizeBegin += new System.EventHandler(Simulator_ResizeBegin);
    		this.ResizeEnd += new System.EventHandler(Simulator_ResizeEnd);
    	}
    	
    	void Simulator_ResizeEnd(object sender, System.EventArgs e)
    	{
    		this.oldWidth = this.Width;
    		this.oldHeight = this.Height;
    	}
    	
    	void Simulator_ResizeBegin(object sender, System.EventArgs e)
    	{
    		int wider = this.Width - this.oldWidth;
    		int higher = this.Height - this.oldHeight;
    		// Change size of UI elements.
    	}
    }
