    public class SearchViewModel : INotifyPropertyChanged
    {
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }
        public void Search(string searchPhrase)
        {
            IsBusy = true;
            Task.Factory
                .StartNew(p =>
                {
                    // This is where you do your database thing and return your results
                }, searchPhrase)
                .ContinueWith(t =>
                {
                    // And this is where you use the returned results in t.Result
                    // don't forget to check for errors :)
                    IsBusy = false;
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
