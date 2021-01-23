    namespace WpfApplication1
    {
        using System.Collections.ObjectModel;
        using System.Windows.Controls;
    
        class UserControl1ViewModel : INotifyPropertyChanged
        {
            // Ultimately, this field (text) would be moved to a model along with any other data fields for this view but for the sake of space, I've put it in the ViewModel
            private string text = "";
            public string Text 
            { 
                get { return text; } 
                set 
                { 
                    text = value;
                    RaisePropertyChanged("Text");
                } 
            }
    
            public MainWindowViewModel()
            {
                Text = "Hello!";
            }
    
            // This is the implementation of INotifyPropertyChanged that is used to inform the UI of changes.
            public event PropertyChangedEventHandler PropertyChanged;
            protected void RaisePropertyChanged(string propertyName)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
