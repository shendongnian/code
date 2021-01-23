    public class MyClass : INotifyPropertyChanged
    {
        public MyClass()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += OnTimerTick;
            timer.Interval = TimeSpan.FromSeconds(300);
        }
    private void OnTimerTick(object sender, EventArgs e)
        {
            var result = await UpdateGraphPoints();
            MyGraphPoints = this.PopulateTheGraph(result);
        }
        private async Task<List<MyGraphPoint>> UpdateGraphPoints()
        {
            var oper = await YourDatabaseQueryMethod();
            return oper;
        }
        private ObservableCollection<MyGraphPoint> PopulateTheGraph(object result)
        {
            
        }
        private ObservableCollection<MyGraphPoint> myGraphPoints;
        public ObservableCollection<MyGraphPoint> MyGraphPoints
        {
            get { return this.myGraphPoints; }
            set
            {
                myGraphPoints = value;
                OnPropertyChanged("MyGraphPoints");
            }
        }
    private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
}
    public class MyGraphPoint : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int xValue;
        public int XValue
        {
            get { return xValue; }
            set
            {
                this.xValue = value;
                this.OnPropertyChanged("XValue");
            }
        }
        private int yValue;
        public int YValue
        {
            get { return yValue; }
            set
            {
                this.yValue = value;
                this.OnPropertyChanged("YValue");
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
