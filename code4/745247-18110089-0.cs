    public class Chobo2
    {
        public bool IsChecked {get;set;}
    }
    public class Chobo2ViewModel // Your base class and interfaces
    {
        private Chobo2 model;
        public bool IsChecked
        {
            get { return model.IsChecked; }
            set 
            {
                if(model.IsChecked == value) return;
                model.IsChecked = value;
                RaisePropertyChanged("IsChecked");
                RaisePropertyChanged("Visibility");
            }
        }
        public System.Windows.Visibility Visibility
        {
            get 
            { 
                return IsChecked 
                           ? System.Windows.Visibility.Visible
                           : System.Windows.Visibility.Collapsed;
            }
        }
    }
