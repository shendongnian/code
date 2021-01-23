    public class MyViewModel : INotifyPropertyChanged
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                this.RaisePropertyChanged("IsBusy");
            }
        }
        private void BeginWorking()
        {
            this.IsBusy = true;
            //Do the work...
        }
        private void FinishWorking()
        {
            this.IsBusy = false;
        }
        
        //Other implementation, including INotifyPropertyChanged...
    }
