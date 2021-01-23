    private void OnGridKeyUp(object sender, KeyEventArgs e)
    {
        if(vm.mySelectedItem != null && e.Key == Key.Space)
        {
            vm.MySelectedItem.IsChecked = !vm.MySelectedItem.IsChecked;
            e.Handled = true; //this is necessary because otherwise when the checkbox cell is selected, it will apply this keyup and also apply the default behavior for the checkbox
        }
    }
