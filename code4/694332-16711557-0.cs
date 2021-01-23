    using System;
    using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Interop;
    using System.Windows.Media;
    private readonly System.Timers.Timer _resizeTimer = new System.Timers.Timer(500);
    
    public MainWindow() {
      InitializeComponent();
      ...
      SizeChanged += (sender, args) => {
        _resizeTimer.Stop();
        _resizeTimer.Start();
      };
      _resizeTimer.Elapsed +=
        (sender, args) =>
        System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(CenterWindowToCurrentScreen));
    }
    public static double GetDpiFactor(Visual window) {
      HwndSource windowHandleSource = PresentationSource.FromVisual(window) as HwndSource;
      if (windowHandleSource != null && windowHandleSource.CompositionTarget != null) {
        Matrix screenmatrix = windowHandleSource.CompositionTarget.TransformToDevice;
        return screenmatrix.M11;
      }
      return 1;
    }
    private void CenterWindowToCurrentScreen() {
      _resizeTimer.Stop();
      double dpiFactor = GetDpiFactor(this);
      var screen = Screen.FromHandle(new WindowInteropHelper(this).Handle);
      double screenLeft = screen.Bounds.Left / dpiFactor;
      double screenTop = screen.Bounds.Top / dpiFactor;
      double screenWidth = screen.Bounds.Width / dpiFactor;
      double screenHeight = screen.Bounds.Height / dpiFactor;
      Left = ((screenWidth - ActualWidth) / 2) + screenLeft;
      Top = ((screenHeight - ActualHeight) / 2) + screenTop;
    }
