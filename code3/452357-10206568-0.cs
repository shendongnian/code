    public ObservableCollection<int> Numbers { get; private set; }
    public IEnumerable<int> NumbersReverse
    {
        get
        {
            return Numbers.Reverse();
        }
    }
