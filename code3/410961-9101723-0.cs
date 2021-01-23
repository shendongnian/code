    void MyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "SelectedReport")
            DeleteCommand.RaiseCanExecuteChanged();
    }
