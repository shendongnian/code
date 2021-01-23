      private ObservableCollection<Subject> lstsub = new ObservableCollection<Subject>() ;
       
       
        private void itemGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           checkTemp = 1;
            GridView tempObjGridView = new GridView();
            tempObjGridView = sender as GridView;  
            lstsub = tempObjGridView.SelectedItems;
        }
     protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
           yourGridName.SelectedItems = lstsub ;
        }
    
