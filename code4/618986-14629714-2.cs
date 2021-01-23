    private void ExplicitBindingTextBox_Loaded(object sender, RoutedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        if (textBox.DataContext as INotifyPropertyChanged == null)
            throw new InvalidOperationException("...");
        (textBox.DataContext as INotifyPropertyChanged).PropertyChanged +=
                      new PropertyChangedEventHandler(ViewModel_PropertyChanged);
    }
