    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    namespace ListBox
    {
        public class ListBoxViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            
            public ObservableCollection<string> Items {get; private set; }
            private void ExecuteUp()
            {
                if (SelectedIndex == 0)
                    return;
                Items.Move(SelectedIndex, SelectedIndex - 1);
            }
            private void ExecuteDown()
            {
                if (SelectedIndex >= Items.Count - 1)
                    return;
                Items.Move(SelectedIndex, SelectedIndex + 1);
            }
    
            public ICommand Up { get; private set; }
            public ICommand Down { get; private set; }
            private int m_SelectedIndex = 0;
            public int SelectedIndex
            {
                get { return m_SelectedIndex; }
                set
                {
                    m_SelectedIndex = value;
                    OnPropertyChanged("SelectedIndex");
                }
            }
    
            public ListBoxViewModel()
            {
                Items = new ObservableCollection<string>() {"London", "Paris", "Berlin"};
                Up = new RelayCommand(ExecuteUp);
                Down = new RelayCommand(ExecuteDown);
            }
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
