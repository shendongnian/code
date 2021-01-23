    public class YourDataClass
    {
        public Rect YourDataClassBoundsProperty { get; set;}
    }
    public class VisualizationWindow
    {
        public ObservableCollection<YourDataClass> DataCollection = new ObservableDictionary<YourDataClass>();
    }
