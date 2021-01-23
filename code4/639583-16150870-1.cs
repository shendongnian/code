    using System.Drawing;
    using SdlDotNet.Graphics;
    
    public class SdlWindow
    {
    	private Surface screen;	// the display Surface
    
    	/* ctor */
    	public SdlWindow(Size size)
    	{
    		screen = Video.SetVideoMode(size.Width, size.Height);	// create a new sdl Surface and its own window container
    		Video.WindowCaption = "Sdl Window";
    	}
    
    	/* your methods */
    	public void DrawRectangle(Rectangle rect)
    	{
    		screen.Fill(rect, Color.Red);
    		screen.Update();
    	}
    
    	/* cleanup a bit */
    	public void Dispose()
    	{
    		if (screen != null)
    			Video.Close();
    	}
    }
