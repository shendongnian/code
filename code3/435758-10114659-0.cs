      public partial class MainWindow : Gtk.Window
      {
	
	public bool GLinit;
	
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		GLinit = false;
	}
	
	protected virtual void GLWidgetInitialize (object sender, System.EventArgs e)
	{
		//this might be overkill to some people, but worked for me
		
		int width = 0, height = 0;	
		this.vbox3.GetSizeRequest(out width, out height);
		float aspectRatio = width/ height; 
		GL.Viewport(0, 0, width, height);
		GL.ClearColor(1.0f, 1.0f,1.0f,1.0f);
		GL.Clear(ClearBufferMask.ColorBufferBit);
		GL.MatrixMode(MatrixMode.Modelview);
		GL.LoadIdentity();
		GL.ShadeModel(ShadingModel.Smooth);			
		Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, aspectRatio, 1.0f, 64.0f);
		GL.MatrixMode(MatrixMode.Projection);			
        GL.LoadMatrix(ref projection);			
        GL.ClearDepth(1);	           
        GL.Disable(EnableCap.DepthTest);	
        GL.Enable(EnableCap.Texture2D); 
        GL.Enable(EnableCap.Blend);
        GL.DepthFunc(DepthFunction.Always);		
		GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest); 
		//add idle event handler to process rendering whenever and as long as time is availble.
		GLinit = true;
		GLib.Idle.Add(new GLib.IdleHandler(OnIdleProcessMain));
 			
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	
	protected void RenderFrame(){
		
		//Here's where you write your OpenGL code to draw whatever you want
                //Don't forget to swap your buffers
		
            OpenTK.Graphics.GraphicsContext.CurrentContext.SwapBuffers();
		
	}
		
	protected bool OnIdleProcessMain ()
	{
		if (!GLinit) return false;
		else{
        	     RenderFrame();
		     return true;
		}
	}	
     }
