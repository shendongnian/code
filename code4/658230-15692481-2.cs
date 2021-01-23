    public class ScreenRequest: INotifyPropertyChanged
        {
            public Command SomeAction { get; set; }
    
            private string _actionDescription;
            public string ActionDescription
            {
                get { return _actionDescription; }
                set
                {
                    _actionDescription = value;
                    NotifyPropertyChanged("ActionDescription");
                }
            }
    
            private string _details;
            public string Details
            {
                get { return _details; }
                set
                {
                    _details = value;
                    NotifyPropertyChanged("Details");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public ScreenRequest()
            {
                SomeAction = new Command(ExecuteSomeAction) {IsEnabled = true};
            }
    
            //public SomeProperty YourProperty { get; set; }
    
            private void ExecuteSomeAction()
            {
                //Place your custom logic here based on YourProperty
                ActionDescription = "Clicked!!";
                Details = "Some Details";
            }
        }
