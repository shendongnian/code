    public class ProductWorkItem : INotifyPropertyChanged
    {
        public string Name{ get; set; }
        public string Description{ get; set; }
        public string Brand{ get; set; }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }
