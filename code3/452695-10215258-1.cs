    public class ViewModel
    {
        public ObservableCollection<CustomETO_GridResult> Results {get;set;}
        // Call this method to update the ObservableCollection, obviously could use some optimization
        public void UpdateFromDatabase()
        {
             var query = // make your database query
             Results.Clear();
             foreach(CustomETO_GridResult result in query)
                  Results.add(result);
        }
       
        ... // Initialize ObservableCollection,  do other work, etc.
    }
