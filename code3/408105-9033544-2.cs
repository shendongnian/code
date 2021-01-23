        private void tb_XamlString_Loaded(object sender, RoutedEventArgs routedEventArgs)
        {
            //First get the ViewModel from DataContext
            MyViewModel vm = content.DataContext as MyViewModel;
            FrameworkElement rootObject = XamlReader.Parse(vm.XamlViewData) as FrameworkElement;
            //Add the XAML portion to the Grid content to render the XAML form dynamically!
            content.Children.Add(rootObject);
        }
