	public partial class MyWindow : Window
	{
		readonly Rectangle screenRectangle;
		public MyWindow( System.Windows.Forms.Screen screen )
		{
			screenRectangle = screen.WorkingArea;
			InitializeComponent();
		}
		[DllImport( "user32.dll", SetLastError = true )]
		static extern bool MoveWindow( IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint );
		protected override void OnSourceInitialized( EventArgs e )
		{
			base.OnSourceInitialized( e );
			var wih = new WindowInteropHelper( this );
			IntPtr hWnd = wih.Handle;
			MoveWindow( hWnd, screenRectangle.Left, screenRectangle.Top, screenRectangle.Width, screenRectangle.Height, false );
		}
		void Window_Loaded( object sender, RoutedEventArgs e )
		{
			WindowState = WindowState.Maximized;
		}
	}
