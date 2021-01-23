	protected override void CreateHandle()
	{
		// Create the render window
		mRenderWindow = new RenderWindow(this);
		mRenderWindow.Width = (uint)base.ClientSize.Width;
		mRenderWindow.Height = (uint)base.ClientSize.Height;
		
		// "Select" device pixel format before creating control handle
		switch (Environment.OSVersion.Platform) {
			case PlatformID.Win32Windows:
			case PlatformID.Win32NT:
				mRenderWindow.PreCreateObjectWgl(SurfaceFormat);
				break;
			case PlatformID.Unix:
				mRenderWindow.PreCreateObjectX11(SurfaceFormat);
				break;
		}
		
		// OVerride default swap interval
		mRenderWindow.SwapInterval = SwapInterval;
		
		// Base implementation
		base.CreateHandle();
	}
	
	/// <summary>
	/// Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated"/> event.
	/// </summary>
	/// <param name="e">
	/// An <see cref="T:System.EventArgs"/> that contains the event data.
	/// </param>
	protected override void OnHandleCreated(EventArgs e)
	{
		if (DesignMode == false) {
			// Finalize control handle creation
			// - WGL: SetPixelFormat
			// - GLX: store FBConfig and XVisualInfo selected in CreateHandle()
			// ...
			// - Setup swap interval, if supported
			mRenderWindow.Create((RenderContext)null);
			// Create the render context (before event handling)
			mRenderContext = new RenderContext(mRenderWindow.GetDeviceContext(), mRenderContextFlags);
		}
		// Base implementation
		base.OnHandleCreated(e);
		// Raise CreateContext event
		if (DesignMode == false) {
			mRenderContext.MakeCurrent(true);
			RaiseCreateContextEvent(new RenderEventArgs(mRenderContext, mRenderWindow));
			mRenderContext.MakeCurrent(false);
		}
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="e"></param>
	protected override void OnHandleDestroyed(EventArgs e)
	{
		if (DesignMode == false) {
			if (mRenderContext != null) {
				// Raise DestroyContext event
				mRenderContext.MakeCurrent(true);
				RaiseDestroyContextEvent(new RenderEventArgs(mRenderContext, mRenderWindow));
				mRenderContext.MakeCurrent(false);
				// Dispose the renderer context
				mRenderContext.Dispose();
				mRenderContext = null;
			}
			// Dispose the renderer window
			if (mRenderWindow != null) {
				mRenderWindow.Dispose();
				mRenderWindow = null;
			}
		}
		// Base implementation
		base.OnHandleDestroyed(e);
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="e"></param>
	protected override void OnPaint(PaintEventArgs e)
	{
		if (DesignMode == false) {
			if (mRenderContext != null) {
				// Render the UserControl
				mRenderContext.MakeCurrent(true);
				// Define viewport
				OpenGL.Gl.Viewport(0, 0, ClientSize.Width, ClientSize.Height);
				// Derived class implementation
				try {
					RenderThis(mRenderContext);
				} catch (Exception exception) {
					
				}
				
				// Render event
				RaiseRenderEvent(new RenderEventArgs(mRenderContext, mRenderWindow));
				// Swap buffers if double-buffering
				Surface.SwapSurface();
				// Base implementation
				base.OnPaint(e);
				mRenderContext.MakeCurrent(false);
			} else {
				e.Graphics.DrawLines(mFailurePen, new Point[] {
					new Point(e.ClipRectangle.Left, e.ClipRectangle.Bottom), new Point(e.ClipRectangle.Right, e.ClipRectangle.Top),
					new Point(e.ClipRectangle.Left, e.ClipRectangle.Top), new Point(e.ClipRectangle.Right, e.ClipRectangle.Bottom),
				});
				// Base implementation
				base.OnPaint(e);
			}
		} else {
			e.Graphics.Clear(Color.Black);
			e.Graphics.DrawLines(mDesignPen, new Point[] {
					new Point(e.ClipRectangle.Left, e.ClipRectangle.Bottom), new Point(e.ClipRectangle.Right, e.ClipRectangle.Top),
					new Point(e.ClipRectangle.Left, e.ClipRectangle.Top), new Point(e.ClipRectangle.Right, e.ClipRectangle.Bottom),
				});
			// Base implementation
			base.OnPaint(e);
		}
	}
	
	protected override void OnClientSizeChanged(EventArgs e)
	{
		if (mRenderWindow != null) {
			mRenderWindow.Width = (uint)base.ClientSize.Width;
			mRenderWindow.Height = (uint)base.ClientSize.Height;
		}
		
		// Base implementation
		base.OnClientSizeChanged(e);
	}
	
	private static readonly Pen mFailurePen = new Pen(Color.Red, 1.5f);
	private static readonly Pen mDesignPen = new Pen(Color.Green, 1.0f);
	#endregion
