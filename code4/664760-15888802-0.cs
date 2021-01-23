    private void Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ViewModelClass vm = this.DataContext as ViewMoedlClass;
        if (vm != null)
        {
            vm.RefreshCommand.Execute();
        }
    }
