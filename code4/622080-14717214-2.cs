    public class WaferTrackerWindowViewModel :INotifyPropertyChanged
    {
        private SelectWaferButtonViewModel btnSelectWaferViewModel;
        public SelectWaferButtonViewModel MyButton 
        {
            get { return btnSelectWaferViewModel; }
            set
            {
                btnSelectWaferViewModel = value;
                OnPropertyChanged("MyButton");
            }
        }
        //......
