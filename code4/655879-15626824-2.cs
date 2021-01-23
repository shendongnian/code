    public sealed class Counter : IEnumerable<MyClass> , INotifyPropertyChanged
    {
        private List<MyClass> m_Collection;
    
        public Int32 Count
        {
            get { return m_Collection.Count; }
        }
    
        public void Add(MyClass item)
        {
            m_Collection.Add(item);
            if (PropertyChanged != null)
                PropertyChanged(null, new PropertyChangedEventArgs("Count"));
        }
    public event PropertyChangedEventHandler PropertyChanged;
