    public class Ticker : INotifyPropertyChanged
    {
        public Ticker()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
    
        void timer_Tick(object sender, object e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Now"));
        }
    
        public string Now
        {
            get { return string.Format("{0:HH:mm:ss tt}", DateTime.Now); }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }
