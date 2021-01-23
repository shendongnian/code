       public ObservableCollection<SampleClass> MyCollection {get; set;}
       private void Window_Loaded(object sender, RoutedEventArgs e)
       {
        //if i set the ItemsSource here, updating of the UI works
          dataGrid1.ItemsSource = MyCollection;
       }
