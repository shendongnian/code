        public class MyViewModel : INotifyPropertyChanged
        {
            public ICommand UpdateSomething { get; private set; }
            public MyViewModel()
            {
                UpdateSomething = new RelayCommand(MyCommandExecute, true);
            }
            private void MyCommandExecute(object parameter)
            {
                // Your logic here, for example using your converter if
                // you really need it.
                // At the end, update the properties you need
                // For example adding a item to an ObservableCollection.
            }
        }
