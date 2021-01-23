       public class MyViewModel : ViewModelBase
       {
           private void OnTimerTick()
           {
               OnPropertyChanged("Date");
           }
           public string Date
           {
               get{ return DateTime.Now().AddSeconds(-5).ToString();
           }
       }
