    using System.ComponentModel;
    
    namespace ComboBoxWrapperSample
    {
        public class Person : INotifyPropertyChanged
        {
            // Declare the event
            public event PropertyChangedEventHandler PropertyChanged;
    
            public Person()
            {
            }
    
            // Name property
            private string _name;
    
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
    
            // Age property
            private int _age;
    
            public int Age
            {
                get { return _age; }
                set
                {
                    _age = value;
                    OnPropertyChanged("Age");
                }
            }
    
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
    
            // Don't forget this override, since it's what defines ao each combo item is shown
            public override string ToString()
            {
                return string.Format("{0} (age {1})", Name, Age);
            }
        }
    }
