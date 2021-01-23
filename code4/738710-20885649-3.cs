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
          //RecurrenceInterval.None is used as a new reminder will be created for every 4  hours in your case
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
          ScheduledActionService.Add(reminder);
           
           //inserting reminder for IntervalHours, let say at interval of 4 hours and will added after each IntervalHours upto Frequency(number of time)
           if (IntervalHours > 0)
            {
                //i is started from 1 as 1 reminder added above
                for (int i = 1; i < Frequency; i++)
                {                    
                    name = System.Guid.NewGuid().ToString();
                    reminder = new Reminder(name);
                    reminder.RecurrenceType = recurrence;
                    reminder.Title = title;
                    reminder.Content = content;
                    reminder.BeginTime = beginTime.AddHours(IntervalHours*i);
                    reminder.ExpirationTime = expirationTime.AddHours(IntervalHours*i);
                    reminder.RecurrenceType = recurrence;
                    reminder.NavigationUri = navigationUri;
                    ScheduledActionService.Add(reminder);
                }
            }
 
