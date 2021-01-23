        public class CronjobViewModel
        {
            public ObservableCollection<Cronjob> Cronjobs { get; private set; }
    
            public CronjobViewModel()
            {
                this.Cronjobs = new ObservableCollection<Cronjob>();
                this.Cronjobs.Add(new Cronjob());
                this.Cronjobs.Add(new Cronjob());
            }
        }
