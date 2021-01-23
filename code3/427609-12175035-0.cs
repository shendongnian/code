        private void PhoneApplicationPage_Loaded(object sender, EventArgs e)
        {
            DataContext = App.ViewModel.something;
            if (MyListPicker.SelectedIndex == -1)
            {
                MyListPicker.ItemsSource   = App.ViewModel.SomeList;
                MyListPicker.SelectedIndex = App.ViewModel.MyBinding;
            }
        }
