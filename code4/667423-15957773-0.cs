    public sealed class YourClass : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) { this.PropertyChanged.Raise(this, new PropertyChangedEventArgs(propertyName)); } // my 'raise' use typical event handling  
        public static readonly YourClass Instance = new YourClass(); // your ctor params if needed
        private YourClass() // ensure only you can 'construct'
        { }
        // call OnPropertyChanged from your properties
        // implement 'non-static' properties
