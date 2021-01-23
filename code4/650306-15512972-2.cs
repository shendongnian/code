    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    namespace WpfApplication1
    {
        public class ViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            private bool _blackOpen;
            public bool BlackOpen { get { return _blackOpen; } set { _blackOpen = value; OnPropertyChanged("BlackOpen"); } }
            private bool _yellowOpen;
            public bool YellowOpen { get { return _yellowOpen; } set { _yellowOpen = value; OnPropertyChanged("YellowOpen"); } }
            private bool _purpleOpen;
            public bool PurpleOpen { get { return _purpleOpen; } set { _purpleOpen = value; OnPropertyChanged("PurpleOpen"); } }
            public ICommand OpenBlackCommand { get; private set; }
            public ICommand OpenYellowCommand { get; private set; }
            public ICommand OpenPurpleCommand { get; private set; }
            public ViewModel()
            {
                this.OpenBlackCommand = new ActionCommand<bool>(OpenBlack);
                this.OpenYellowCommand = new ActionCommand<bool>(OpenYellow);
                this.OpenPurpleCommand = new ActionCommand<bool>(OpenPurple);
            }
            private void OpenBlack(bool open) { this.BlackOpen = open; }
            private void OpenYellow(bool open) { this.YellowOpen = open; }
            private void OpenPurple(bool open) { this.PurpleOpen = open; }
        }
        public class ActionCommand<T> : ICommand
        {
            public event EventHandler CanExecuteChanged;
            private Action<T> _action;
            public ActionCommand(Action<T> action)
            {
                _action = action;
            }
            public bool CanExecute(object parameter) { return true; }
            public void Execute(object parameter)
            {
                if (_action != null)
                {
                    var castParameter = (T)Convert.ChangeType(parameter, typeof(T));
                    _action(castParameter);
                }
            }
        }
    }
