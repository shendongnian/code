    private void MyCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        if (e.Source == button1)
            e.CanExecute = checkBox1.IsChecked.HasValue ? checkBox1.IsChecked.Value : false;
        if (e.Source == button2)
            e.CanExecute = checkBox2.IsChecked.HasValue ? checkBox2.IsChecked.Value : false;
        if (e.Source == button3)
            e.CanExecute = checkBox3.IsChecked.HasValue ? checkBox3.IsChecked.Value : false;
    }
