    // Data binding class
    public class Data
    {
        // Implement INofifyPropertyChanged
        public string Text { get; set; }
    }
    
    // Code to bind it to Pivot
    
    ObservableCollection<Data> list = new ObservableCollection<Data>();
    // populate list
    Pivot1.ItemsSource = list;
