    public class MyModel : INotifyPropertyChanged
    {
      ...
        public DateTime StartTime
        {
            get { return _startTime; }
            set 
            {
                 if ((EndTime - value).TotalMinutes >= 0) // only allow changes if it doesn't result in < 0 timespan.
                 {
                     _startTime = value;
                     OnPropertyChanged("StartTime", "Length");
                 }
            }
        }
        public DateTime EndTime
        {
            get { return _endTime; }
            set 
            {
                 if ((value - StartTime).TotalMinutes >= 0) 
                 {
                     _endTime = value;
                     OnPropertyChanged("EndTime", "Length");
                 }
            }
        }
        public double Length
        {
             get { return (EndTime - StartTime).TotalMinutes / 60.0; }           
        }
      ...
    }
