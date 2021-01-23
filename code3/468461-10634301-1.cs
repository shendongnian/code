     ObservableCollection<Seive> _seiveData;
            public ObservableCollection<Seive> SeiveData
            {
                get { return _seiveData; }
                set { _seiveData = value; }
            }
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
    
                SeiveData = new ObservableCollection<Seive>();
                SeiveData.Add(new Seive("+10"));
                SeiveData.Add(new Seive("+8"));
             
                serverGrid.DataContext = SeiveData;
    
            }
