    using System;
    using System.Windows;
    using System.Windows.Threading;
    
    namespace CountdownTimer
    {
        public partial class MainWindow : Window
        {
            DispatcherTimer _timer;
            TimeSpan _time;
    
            public MainWindow()
            {
                InitializeComponent();
    
                _time = TimeSpan.FromSeconds(10);
    
                _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                    {
                        tbTime.Text = _time.ToString("c");
                        if (_time == TimeSpan.Zero) _timer.Stop();
                        _time = _time.Add(TimeSpan.FromSeconds(-1));                    
                    }, Application.Current.Dispatcher);
    
                _timer.Start();            
            }
        }
    }
