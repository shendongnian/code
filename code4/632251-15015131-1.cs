    		private const int WM_SYSCOMMAND = 0X112;
		private HwndSource hwndSource;
		enum SWP : uint
		{
			NOSIZE = 0x0001 ,
			NOMOVE = 0x0002 ,
			NOZORDER = 0x0004 ,
			NOREDRAW = 0x0008 ,
			NOACTIVATE = 0x0010 ,
			FRAMECHANGED = 0x0020 ,  
			SHOWWINDOW = 0x0040 ,
			HIDEWINDOW = 0x0080 ,
			NOCOPYBITS = 0x0100 ,
			NOOWNERZORDER = 0x0200 , 
			NOSENDCHANGING = 0x0400 , 
		}
		public override void OnApplyTemplate()
		{
			System.IntPtr handle = ( new WindowInteropHelper( this ) ).Handle;
			HwndSource.FromHwnd( handle ).AddHook( new HwndSourceHook( WindowProc ) );
		}
		private System.IntPtr WindowProc( System.IntPtr hwnd , int msg , System.IntPtr wParam , System.IntPtr lParam , ref bool handled )
		{
			switch ( msg )
			{
				case 0x0024:
					{
						WmGetMinMaxInfo( hwnd , lParam );
						handled = true;
						break;
					}
				case 0x0046:
					{
						WINDOWPOS pos = ( WINDOWPOS )Marshal.PtrToStructure( lParam , typeof( WINDOWPOS ) );
						if ( ( pos.flags & ( int )(SWP.NOMOVE) ) != 0 )
						{
							return IntPtr.Zero;
						}
						Window wnd = ( Window )HwndSource.FromHwnd( hwnd ).RootVisual;
						if ( wnd == null )
						{
							return IntPtr.Zero;
						}
						bool changedPos = false;
						if ( pos.cx < MinWidth ) { pos.cx = (int)MinWidth; changedPos = true; }
						if ( pos.cy < MinHeight ) { pos.cy = ( int )MinHeight; changedPos = true; }
						if ( !changedPos )
						{
							return IntPtr.Zero;
						}
						Marshal.StructureToPtr( pos , lParam , true );
						handled = true;
						break;
					}
			}
			return ( System.IntPtr )0;
		}
		private void WmGetMinMaxInfo( System.IntPtr hwnd , System.IntPtr lParam )
		{
			MINMAXINFO mmi = ( MINMAXINFO )Marshal.PtrToStructure( lParam , typeof( MINMAXINFO ) );
			int MONITOR_DEFAULTTONEAREST = 0x00000002;
			System.IntPtr monitor = MonitorFromWindow( hwnd , MONITOR_DEFAULTTONEAREST );
			if ( monitor != System.IntPtr.Zero )
			{
				MONITORINFO monitorInfo = new MONITORINFO();
				GetMonitorInfo( monitor , monitorInfo );
				RECT rcWorkArea = monitorInfo.rcWork;
				RECT rcMonitorArea = monitorInfo.rcMonitor;
				mmi.ptMaxPosition.x = Math.Abs( rcWorkArea.left - rcMonitorArea.left );
				mmi.ptMaxPosition.y = Math.Abs( rcWorkArea.top - rcMonitorArea.top );
				mmi.ptMaxSize.x = Math.Abs( rcWorkArea.right - rcWorkArea.left );
				mmi.ptMaxSize.y = Math.Abs( rcWorkArea.bottom - rcWorkArea.top );
			}
			Marshal.StructureToPtr( mmi , lParam , true );
		}
		[StructLayout( LayoutKind.Sequential )]
		public struct POINT
		{
			public int x;
			public int y;
			public POINT( int x , int y )
			{
				this.x = x;
				this.y = y;
			}
		}
		[StructLayout( LayoutKind.Sequential )]
		public struct MINMAXINFO
		{
			public POINT ptReserved;
			public POINT ptMaxSize;
			public POINT ptMaxPosition;
			public POINT ptMinTrackSize;
			public POINT ptMaxTrackSize;
		};
		[StructLayout( LayoutKind.Sequential , CharSet = CharSet.Auto )]
		public class MONITORINFO
		{
			public int cbSize = Marshal.SizeOf( typeof( MONITORINFO ) );
			public RECT rcMonitor = new RECT();
			public RECT rcWork = new RECT();
			public int dwFlags = 0;
		}
		[StructLayout( LayoutKind.Sequential , Pack = 0 )]
		public struct RECT
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
			public static readonly RECT Empty = new RECT();
			public int Width
			{
				get { return Math.Abs( right - left ); }
			}
			public int Height
			{
				get { return bottom - top; }
			}
			public RECT( int left , int top , int right , int bottom )
			{
				this.left = left;
				this.top = top;
				this.right = right;
				this.bottom = bottom;
			}
			public RECT( RECT rcSrc )
			{
				this.left = rcSrc.left;
				this.top = rcSrc.top;
				this.right = rcSrc.right;
				this.bottom = rcSrc.bottom;
			}
			public bool IsEmpty
			{
				get
				{
					return left >= right || top >= bottom;
				}
			}
			public override string ToString()
			{
				if ( this == RECT.Empty ) { return "RECT {Empty}"; }
				return "RECT { left : " + left + " / top : " + top + " / right : " + right + " / bottom : " + bottom + " }";
			}
			public override bool Equals( object obj )
			{
				if ( !( obj is Rect ) ) { return false; }
				return ( this == ( RECT )obj );
			}
			public override int GetHashCode()
			{
				return left.GetHashCode() + top.GetHashCode() + right.GetHashCode() + bottom.GetHashCode();
			}
			public static bool operator ==( RECT rect1 , RECT rect2 )
			{
				return ( rect1.left == rect2.left && rect1.top == rect2.top && rect1.right == rect2.right && rect1.bottom == rect2.bottom );
			}
			public static bool operator !=( RECT rect1 , RECT rect2 )
			{
				return !( rect1 == rect2 );
			}
		}
		[DllImport( "user32" )]
		internal static extern bool GetMonitorInfo( IntPtr hMonitor , MONITORINFO lpmi );
		[DllImport( "User32" )]
		internal static extern IntPtr MonitorFromWindow( IntPtr handle , int flags );
		[StructLayout( LayoutKind.Sequential )]
		internal struct WINDOWPOS
		{
			public IntPtr hwnd;
			public IntPtr hwndInsertAfter;
			public int x;
			public int y;
			public int cx;
			public int cy;
			public int flags;
		}
		private void InitializeWindowSource( object sender , EventArgs e )
		{
			hwndSource = PresentationSource.FromVisual( ( Visual )sender ) as HwndSource;
		}
		public enum ResizeDirection
		{
			Left = 1 ,
			Right = 2 ,
			Top = 3 ,
			TopLeft = 4 ,
			TopRight = 5 ,
			Bottom = 6 ,
			BottomLeft = 7 ,
			BottomRight = 8 ,
		}
		[DllImport( "user32" , CharSet = CharSet.Auto )]
		private static extern IntPtr SendMessage( IntPtr hWnd , uint Msg , IntPtr wParam , IntPtr lParam );
		private void ResizeWindow( ResizeDirection direction )
		{
			SendMessage( hwndSource.Handle , WM_SYSCOMMAND , ( IntPtr )( 61440 + direction ) , IntPtr.Zero );
		}
