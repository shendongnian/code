    using System.ComponentModel;
    using System.Windows;
    
    namespace SimpleMVVM
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private Dog _dog = new Dog();
    
            public MainWindow()
            {
                InitializeComponent();
    
                DataContext = _dog;
                button.Click += (sender, e) => _dog.Name = "Taylor" ;
            }
        }
    
        public class Dog : Animal
        {
            public Dog()
            {
            }        
        }
    
        public class Animal : INotifyPropertyChanged
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
