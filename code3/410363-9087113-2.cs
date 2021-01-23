    using System.Threading;
    class ImageScroller
    {
        // Tick every 42 millisecond or about 24 times per second
        private readonly int _refreshRate = 42;
        private volatile bool _scrolling;
        private Timer _timer;
        ImageScroller()
        {
            _timer = new Timer(TimerTick, null, 0, _refreshRate);
        }
        public void TimerTick(object state)
        {
            if (_scrolling)
            {
                ShowCurrent();
                HideInvisibleImages();
            }
        }
        void ShowCurrent()
        {
            //...
        }
        void HideInvisibleImages()
        {
            //...
        }
    }
