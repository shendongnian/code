    bool change = true;
    if (/*selection would cause irreversible changes*/)
    { 
        if (prompt)
        {
            MessageBoxResult result = Microsoft.Windows.Controls.MessageBox.Show(
                    "bla bla bla",
                    "bla",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes) change = false;
        }
        if (change) PerformIrreversibleChanges()
    }
    if (change) _afield = value;
    NotifyPropertyChanged("Afield");
