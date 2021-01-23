    public class ButtonObserver : IDisposable
    {
        public struct MouseButtons
        {
            public bool LeftButton;
            public bool RightButton;
        }
        
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vKey);
        private const int VK_LBUTTON = 0x01;
        private const int VK_RBUTTON = 0x02;
        
        private Task _pollTask = null;
        private Subject<MouseButtons> _pollBuffer = new Subject<MouseButtons>();
        private CancellationTokenSource _canceller;
        
        public IObservable<MouseButtons> PollMouse(int pollDelayMs)
        {
            if(_pollTask == null)
            {
                _canceller = new CancellationTokenSource();
                _pollTask = Task.Factory.StartNew(() =>
                {
                    while(!_canceller.IsCancellationRequested)
                    {
                        var mbLeft = GetAsyncKeyState(VK_LBUTTON) != 0;
                        var mbRight = GetAsyncKeyState(VK_RBUTTON) != 0;
                        _pollBuffer.OnNext(new MouseButtons{ LeftButton = mbLeft, RightButton = mbRight});
                        Thread.Sleep(pollDelayMs);
                    }
                });            
            }
            return _pollBuffer;
        }
        
        public void Dispose()
        {
            _canceller.Cancel();
            _pollTask.Wait();
            _pollTask = null;
        }
    }
