    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Interop;
    using System.Windows.Media;
    
    namespace dwm
    {
    	public partial class MainWindow
    	{
    		[DllImport("dwmapi.dll", PreserveSig = false)]
    		public static extern void DwmEnableBlurBehindWindow(IntPtr hwnd, ref DwmBlurbehind blurBehind);
    		
    		[DllImport("dwmapi.dll", PreserveSig = true)]
    		private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
    
    		public MainWindow()
    		{
    			InitializeComponent();
    		}
    
    		protected override void OnSourceInitialized(EventArgs e)
    		{
    			base.OnSourceInitialized(e);
    
    			var bb = new DwmBlurbehind
    			{
    				dwFlags = CoreNativeMethods.DwmBlurBehindDwFlags.DwmBbEnable,
    				Enabled = true
    			};
    
    			WindowStartupLocation = WindowStartupLocation.CenterScreen;
    			Background = Brushes.Transparent;
    			ResizeMode = ResizeMode.NoResize;
    			//WindowStyle = WindowStyle.None;
    
    			Focus();
    
    			var hwnd = new WindowInteropHelper(this).Handle;
    
    			HwndSource.FromHwnd(hwnd).CompositionTarget.BackgroundColor = Colors.Transparent;
    
    			DwmEnableBlurBehindWindow(hwnd, ref bb);
    			
    			const int dwmwaNcrenderingPolicy = 2;
    			var dwmncrpDisabled = 2;
    
    			DwmSetWindowAttribute(hwnd, dwmwaNcrenderingPolicy, ref dwmncrpDisabled, sizeof(int));
    		}
    
    		[StructLayout(LayoutKind.Sequential)]
    		public struct DwmBlurbehind
    		{
    			public CoreNativeMethods.DwmBlurBehindDwFlags dwFlags;
    			public bool Enabled;
    			public IntPtr BlurRegion;
    			public bool TransitionOnMaximized;
    		}
    
    		public static class CoreNativeMethods
    		{
    			public enum DwmBlurBehindDwFlags
    			{
    				DwmBbEnable = 1,
    				DwmBbBlurRegion = 2,
    				DwmBbTransitionOnMaximized = 4
    			}
    		}
    	}
    }
