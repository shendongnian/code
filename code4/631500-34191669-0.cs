      public DateTime DateOnly
        {
            get { return _dateOnly.Date; }
            set
            {
                _dateOnly = value.Date;
                Combined = DateOnly.Add(TimeOnly.TimeOfDay);
            }
        }
        public DateTime TimeOnly
        {
            get { return _timeOnly.ToLocalTime(); }
            set
            {
                _timeOnly = value.ToLocalTime();
                Combined = DateOnly.Add(TimeOnly.TimeOfDay);
            }
        }
