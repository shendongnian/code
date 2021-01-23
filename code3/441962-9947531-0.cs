    class MyTimer : INotifyPropertyChanged
    {
        public MyTimer()
        {
            Start();
        }
        private async void Start()
        {
            while (true)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                PropertyChanged(this, new PropertyChangedEventArgs("Time"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public DateTime Time { get { return DateTime.Now; } }
    }
