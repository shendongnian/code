    private ObservableCollection<Sections> indicators = new ObservableCollection<Sections>();
    public IList<Sections> Indicators
    {
        get
        { 
            return indicators;                
        }
    }
    public genericGauge()
    {
        InitializeComponent();
        this.indicators.CollectionChanged += this.IndicatorsCollectionChanged;
    }
    private void IndicatorsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        // possibly inspect the NotifyCollectionChangedEventArgs to see if it's a change that should cause a redraw.
        // or not.
        this.Invalidate();
    }
