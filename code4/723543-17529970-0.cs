XAML
    <Window x:Class="PlayGifHelp.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525" Loaded="MainWindow_Loaded">
    
        <Grid>
            <Image x:Name="SampleImage" />
        </Grid>
    </Window>
Code behind
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Bitmap _bitmap;
        BitmapSource _source;
        private BitmapSource GetSource()
        {
            if (_bitmap == null)
            {
                string path = Directory.GetCurrentDirectory();
                // Check the path to the .gif file
                _bitmap = new Bitmap(path + @"\anim.gif");
            }
            IntPtr handle = IntPtr.Zero;
            handle = _bitmap.GetHbitmap();
            return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _source = GetSource();
            SampleImage.Source = _source;
            ImageAnimator.Animate(_bitmap, OnFrameChanged);
        }
        private void FrameUpdatedCallback()
        {
            ImageAnimator.UpdateFrames();
            if (_source != null)
            {
                _source.Freeze();
            }
            _source = GetSource();
            SampleImage.Source = _source;
            InvalidateVisual();
        }
        private void OnFrameChanged(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(FrameUpdatedCallback));
        }
    }
