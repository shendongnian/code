    public class Alarm
    {
        public delegate void AlarmEvent();
        // my secret stuff
        // raise it!
        public void Ring()
        {
            if(OnAlert != null)
               OnAlert();
        }
        public event AlarmEvent OnAlert;
    }
