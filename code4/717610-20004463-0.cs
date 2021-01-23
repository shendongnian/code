    private void me_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                switch (e.PropertyName)
                {
                    case "whateverPropertyNamethatcontrolsit":
                        ((RelayCommand)FirstCommand).RaiseCanExecuteChanged();
                        break;
                }
            }
