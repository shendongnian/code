    using System.ComponentModel;
    using System.Windows;
    
    namespace SimpleMVVM
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private AnimalViewModel _animal= new AnimalViewModel ();
    
            public MainWindow()
            {
                InitializeComponent();
    
                DataContext = _animal;
                button.Click += (sender, e) => _animal.Name = "Taylor" ;
            }
        }
    
        public class AnimalViewModel : AnimalModel 
        {
            public AnimalViewModel ()
            {
            }        
        }
    
        public class AnimalModel : INotifyPropertyChanged
        {
            private string _name;
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public string Name
            {
                get { return _name; }
                set
                {
                    if (_name != value)
                    {
                        _name = value;
                        OnPropertyChanged("Name");
                    }
                }
            }
    
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                    PropertyChanged(this, args);
                }
            }
        }
    
    }
