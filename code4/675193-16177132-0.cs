    public class MyViewModel : MvxViewModel
    {
        public MyViewModel()
        {
            // subscribe for health updates here
        }
        public class HealthTuple
        {
            public double Old {get;set;}
            public double New {get;set;}
        }
        private HealthTuple _health; 
        public HealthTuple Health 
        {
           get { return _health; }
           set { _health = value; RaisePropertyChanged(() => Health); }
        } 
        private void OnNewHealth(HealthMessage message)
        {
            Health = new HealthTuple() { Old = _health.New, New = message.Value };
        }
    }
