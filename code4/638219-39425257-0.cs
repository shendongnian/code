    public sealed partial class MainPage
    {
        private const int ScrollLoopbackTimeout = 500;
        private object _lastScrollingElement;
        private int _lastScrollChange = Environment.TickCount;
        public SongMixerUserControl()
        {
            InitializeComponent();
        }
        private void SynchronizedScrollerOnViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (_lastScrollingElement != sender && Environment.TickCount - _lastScrollChange < ScrollLoopbackTimeout) return;
            _lastScrollingElement = sender;
            _lastScrollChange = Environment.TickCount;
            ScrollViewer sourceScrollViewer;
            ScrollViewer targetScrollViewer;
            if (sender == ScrollViewer1)
            {
                sourceScrollViewer = ScrollViewer1;
                targetScrollViewer = ScrollViewer2;
            }
            else
            {
                sourceScrollViewer = ScrollViewer2;
                targetScrollViewer = ScrollViewer1;
            }
            targetScrollViewer.ChangeView(null, sourceScrollViewer.VerticalOffset, null);
        }
    }
