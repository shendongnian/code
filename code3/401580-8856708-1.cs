        public DateTime StartTime
        {
            get { return startdate; }
            set
            {
                startdate = new DateTime(value.Year, value.Month, value.Day, startdate.Hour, startdate.Minute, 0);
                RaisePropertyChanged("StartTime");
                RaisePropertyChanged("StartHour");
                RaisePropertyChanged("StartMinute");
            }
        }
        public int StartHour
        {
            get { return StartTime.Hour; }
            set
            {
                startdate = new DateTime(startdate.Year, startdate.Month, startdate.Day, value, startdate.Minute, 0);
            }
        }
