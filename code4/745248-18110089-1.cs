    // Assume the Chobo2 class implements INPC
    public class Chobo2ViewModel // Your base class and interfaces
    {
        private Chobo2 model;
        public Chobo2ViewModel(Chobo2 model)
        {
            // Should check for null here
            this.model = model;
            this.model.PropertyChanged += (sender, args) => 
                {
                    if(args.PropertyName == "IsChecked")
                        RaisePropertyChanged("Visibility")
                }
        }
        public System.Windows.Visibility Visibility
        {
            get 
            { 
                return model.IsChecked 
                           ? System.Windows.Visibility.Visible
                           : System.Windows.Visibility.Collapsed;
            }
        }
    }
