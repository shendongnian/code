        private DateTime? _startDateSelectedDate;
        public DateTime? StartDateSelectedDate
        {
            get { return _startDateSelectedDate; }
            set
            {
                if (_startDateSelectedDate != value)
                {
                    _startDateSelectedDate = value;
                    RaisePropertyChanged(() => this.StartDateSelectedDate);
                }
            }
        }
