    public class DataViewModel
    {
        public DataViewModel(Data data)
        {
            RandomData = new ReadOnlyObservableCollection<String>(data.RandomData);
        }
    
        public ReadOnlyObservableCollection<String> RandomData {get; private set;}
    }
