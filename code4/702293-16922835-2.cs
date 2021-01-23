    public class RootViewModel: PropertyChangedBase
    {
        private double _x;
        public double X
        {
            get { return _x; }
            set
            {
                _x = value;
                OnPropertyChanged("X");
            }
        }
        public ObservableCollection<UserControlViewModel> Children { get; set; }
        public Command AddUserControlCommand { get; set; }
        public RootViewModel()
        {
            Children = new ObservableCollection<UserControlViewModel>();
            AddUserControlCommand = new Command(AddUserControl);
        }
        private void AddUserControl()
        {
            var child = new UserControlViewModel();
            child.PressMeCommand = new Command(() => OnUserControlPressed(child));
            Children.Add(child);
        }
        private void OnUserControlPressed(UserControlViewModel item)
        {
            if (item != null)
            {
                var xy = X * item.Y;
                var resultMessage = string.Format("{0} * {1} = {2}", X, item.Y, xy);
                MessageBox.Show(resultMessage, "X * Y");    
            }
        }
    }
