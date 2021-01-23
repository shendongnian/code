        private int _intervalHours;
        public int IntervalHours
        {
            get
            {
                return _intervalHours;
            }
            set
            {
                _intervalHours = value;
                RaisePropertyChanged("IntervalHours");
            }
        }
        private int _frequency;
        public int Frequency
        {
            get
            {
                return _frequency;
            }
            set
            {
                _frequency = value;
                RaisePropertyChanged("Frequency");
            }
        }
          RecurrenceInterval recurrence = RecurrenceInterval.None;
    
          //inserting staring reminder
          name = System.Guid.NewGuid().ToString();
          reminder = new Reminder(name);
          reminder.RecurrenceType = recurrence;
          reminder.Title = title;
          reminder.Content = content;
          reminder.BeginTime = beginTime;
          reminder.ExpirationTime = expirationTime;
          reminder.RecurrenceType = recurrence;
          reminder.NavigationUri = navigationUri;
           
           //inserting reminder for IntervalHours, let say at interval of 4 hours and will added after each IntervalHours upto Frequency(number of time)
           if (IntervalHours > 0)
            {
                // 1 detected from frequency as 1 reminder add above
                for (int i = 0; i < Frequency-1; i++)
                {                    
                    name = System.Guid.NewGuid().ToString();
                    reminder = new Reminder(name);
                    reminder.RecurrenceType = recurrence;
                    reminder.Title = title;
                    reminder.Content = content;
                    reminder.BeginTime = beginTime.AddHours(IntervalHours);
                    reminder.ExpirationTime = expirationTime.AddHours(IntervalHours);
                    reminder.RecurrenceType = recurrence;
                    reminder.NavigationUri = navigationUri;
                }
            }
