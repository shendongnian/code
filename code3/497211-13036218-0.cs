    public class BlurWindow : Window
    {
    	#region Constants
    	private const int WM_DWMCOMPOSITIONCHANGED = 0x031E;
    	private const int DWM_BB_ENABLE = 0x1; 
    	#endregion //Constants
    	#region Structures
    	[StructLayout( LayoutKind.Sequential )]
    	private struct DWM_BLURBEHIND
    	{
    		public int dwFlags;
    		public bool fEnable;
    		public IntPtr hRgnBlur;
    		public bool fTransitionOnMaximized;
    	}
    	[StructLayout( LayoutKind.Sequential )]
    	private struct MARGINS
    	{
    		public int cxLeftWidth;
    		public int cxRightWidth;
    		public int cyTopHeight;
    		public int cyBottomHeight;
    	} 
    	#endregion //Structures
    	#region APIs
    	[DllImport( "dwmapi.dll", PreserveSig = false )]
    	private static extern void DwmEnableBlurBehindWindow(IntPtr hwnd, ref DWM_BLURBEHIND blurBehind);
    	[DllImport( "dwmapi.dll" )]
    	private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMargins);
    	[DllImport( "dwmapi.dll", PreserveSig = false )]
    	private static extern bool DwmIsCompositionEnabled(); 
    	#endregion //APIs
    	#region Constructor
    	public BlurWindow()
    	{
    		this.WindowStyle = System.Windows.WindowStyle.None;
    		this.ResizeMode = System.Windows.ResizeMode.NoResize;
    		this.Background = Brushes.Transparent;
    	} 
    	#endregion //Constructor
    	#region Base class overrides
    	protected override void OnSourceInitialized(EventArgs e)
    	{
    		base.OnSourceInitialized( e );
    		if ( Environment.OSVersion.Version.Major >= 6 )
    		{
    			var hwnd = new WindowInteropHelper( this ).Handle;
    			var hs = HwndSource.FromHwnd( hwnd );
    			hs.CompositionTarget.BackgroundColor = Colors.Transparent;
    			hs.AddHook( new HwndSourceHook( this.WndProc ) );
    			this.InitializeGlass( hwnd );
    		}
    	} 
    	#endregion //Base class overrides
    	#region Methods
    	#region InitializeGlass
    	private void InitializeGlass(IntPtr hwnd)
    	{
    		if ( !DwmIsCompositionEnabled() )
    			return;
    		// fill the background with glass
    		var margins = new MARGINS();
    		margins.cxLeftWidth = margins.cxRightWidth = margins.cyBottomHeight = margins.cyTopHeight = -1;
    		DwmExtendFrameIntoClientArea( hwnd, ref margins );
    		// initialize blur for the window
    		DWM_BLURBEHIND bbh = new DWM_BLURBEHIND();
    		bbh.fEnable = true;
    		bbh.dwFlags = DWM_BB_ENABLE;
    		DwmEnableBlurBehindWindow( hwnd, ref bbh );
    	}
    	#endregion //InitializeGlass
    	#region WndProc
    	private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    	{
    		if ( msg == WM_DWMCOMPOSITIONCHANGED )
    		{
    			this.InitializeGlass( hwnd );
    			handled = false;
    		}
    		return IntPtr.Zero;
    	} 
    	#endregion //WndProc 
    	#endregion //Methods
    }
