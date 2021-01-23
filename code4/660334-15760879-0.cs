     Doors.CollectionChanged += OnDoorsCollectionChanged; 
     
     private static void OnDoorsCollectionChanged(object sender , CollectionChangedEventArgs e)
     {
          PropertyChanged(sender,new PropertyChangedEventArgs("Doors"));
     }
   
