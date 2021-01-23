         public sealed partial class CustomFlip
        {
        	#region Properties
        
        	private readonly TimeSpan _delay = new TimeSpan(0, 0, 1);
        	private readonly DispatcherTimer _dt;
        
        	#endregion Properties
        
        	#region Control Properties
        
        	public IList<Uri> Pictures
        	{
        		get { return (Uri)GetValue(PicturesProperty); }
        		set { SetValue(PicturesProperty, value); }
        	}
        
        	public static readonly DependencyProperty PicturesProperty
        		= DependencyProperty.Register("Pictures", typeof(Uri), typeof(CustomFlip), null);
        
        	#endregion Control Properties
        
        	public EpgProgressBar()
        	{
        		InitializeComponent();
        		Loaded += CLoaded;
        		_dt = new DispatcherTimer { Interval = _delay };
        		_dt.Tick += Refresh;
        
        		Unloaded += CUnloaded;
        	}
        
        	private void CLoaded(object sender, RoutedEventArgs e)
        	{
        		_dt.Start();
        	}
        
        	private void CUnloaded(object sender, RoutedEventArgs e)
        	{
        		_dt.Stop();
        	}
        
        	private void Refresh(object sender, object e)
        	{
        		//Image name in your xaml.
        		foo.Source = //Random Uri from Pictures.
    //Sample this.MyImage.Source = new BitmapImage(new Uri("/MyNameSpace;images/someimage.png", UriKind.Relative));
        	}
        
        	#region Methods
        
        	public void StopRefresh()
        	{
        		_dt.Stop();
        	}
        
        	public void ReStartRefresh()
        	{
        		if (_dt == null)
        			return;
        
        		_dt.Start();
        	}
        
        	#endregion Methods
        }
