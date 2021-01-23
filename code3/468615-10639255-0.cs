    public class PrayerViewModel : DependencyObject
        public PrayerViewModel ()
        {
             // TODO: Start off a new thread that Raises the PropertyChanged() Event for each property at the right time
        }
        public string Result
        {
             get
             {
                TimeSpan currentTime = myDay.TimeOfDay;
                if (currentTime >= obj.Fajr && currentTime < obj.Sunrise)
                {
                    return "Fajr";
                }
                else if (currentTime >= obj.Sunrise && currentTime < obj.Zohr)
                {
                    return "Sunrise";
                }
            }
        }
        public string Prayer
        {
             get
             {
                TimeSpan currentTime = myDay.TimeOfDay;
                if (currentTime >= obj.Fajr && currentTime < obj.Sunrise)
                {
                    Prayer = obj.Fajr.ToString(@"hh\:mm");
                }
                else if (currentTime >= obj.Sunrise && currentTime < obj.Zohr)
                {
                    Prayer = obj.Sunrise.ToString(@"hh\:mm");
                }
            }
        }
    }
