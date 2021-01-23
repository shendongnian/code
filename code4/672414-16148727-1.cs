    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<string> _fragments;
        public ObservableCollection<string> Fragments { get { return _fragments; } set { _fragments = value; OnPropertyChanged("Fragments"); } }
        public ViewModel()
        {
            Fragments = new ObservableCollection<string>();
            Fragments.Add("This is ");
            Fragments.Add("the first line, ");
            Fragments.Add("it is very long and will drift to the ");
            Fragments.Add("second line naturally since it is controlled by a wrap panel");
            Fragments.Add("\nThis I want to force to the line below where the line above ends\n");
            Fragments.Add("rapid \nnew \nlines");
        }
    }
