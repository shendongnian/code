    using System;
    using System.Linq;
    using System.Windows;
    using System.ComponentModel;
    
    namespace WpfApplication4
    {
        public partial class Window13 : Window
        {
            public Window13()
            {
                var rnd = new Random();
                InitializeComponent();
                DataContext = Enumerable.Range(0, 48).Select(x => new Square() {State = rnd.Next(0,5) > 3});
            }
        }
    
        public class Square:INotifyPropertyChanged
        {
            private bool _state;
            public bool State
            {
                get { return _state; }
                set
                {
                    _state = value;
                    NotifyPropertyChanged("State");
                }
            }
    
            private DelegateCommand _toggleCommand;
            public DelegateCommand ToggleCommand
            {
                get { return _toggleCommand ?? (_toggleCommand = new DelegateCommand(x => State = !State)); }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
