    void MyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "SelectedIndex")
            RunTabChangedLogic();
    }
