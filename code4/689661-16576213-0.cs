    public class ImageGenerator : IServiceProvider, IGraphicsDeviceService
    {
    	public GraphicsDevice GraphicsDevice { get; private set; }
        public ContentManager ContentManager { get; private set; }
			
        public ImageGenerator( GraphicsDevice device )
        {
            this.GraphicsDevice = device;
            this.ContentManager = new ContentManager( this );
        }
        public object GetService(Type serviceType)
		{
			if (serviceType == typeof(IGraphicsDeviceService))
			{
    			return this;
			}
			return null;
		}
		public event EventHandler<EventArgs> DeviceCreated;
		public event EventHandler<EventArgs> DeviceDisposing;
		public event EventHandler<EventArgs> DeviceReset;
		public event EventHandler<EventArgs> DeviceResetting;
    }
