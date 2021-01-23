    private IEnumerable<MyDataObject>[] _pages;
    private int _currentPageIndex = 0;
    private ObservableCollection<MyDataObject> _visibleData;
    private DispatcherTimer _timer;
    public MainPage()
    {
        InitializeComponent();
        this._visibleData = new ObservableCollection<MyDataObject>();
        this.MyDataGrid.ItemsSource = this._visibleData;
        this._timer = new DispatcherTimer();
        this._timer.Interval = TimeSpan.FromMinutes(1);
        this._timer.Tick += (sender, args) => this.OnTimerTick();
        this._timer.Start();
    }
    // I assume you have some code that gets data from the server. Pass that data to this method.
    private void ProcessDataFromServer(IEnumerable<MyDataObject> data)
    {
        this._pages = this.GroupDataIntoPages(data);
        this.ShowPage(0);
    }
    private IEnumerable<MyDataObject>[] GroupDataIntoPages(IEnumerable<MyDataObject> data)
    {
        // I'll leave this to you.
        // This might help: http://stackoverflow.com/a/860399/674077
    }
    private void OnTimerTick()
    {
        if(this._pages != null)
        {
            this._currentPageIndex++;
            if(this._currentPageIndex >= this._pages.Length)
            {
                this._currentPageIndex = 0;
            }
            this.ShowPage(this._currentPageIndex);
        }
    }
    private void ShowPage(int pageIndex)
    {
        this._visibleData.Clear();
        if(this._pages != null && pageIndex >= 0 && pageIndex < this._pages.Length)
        {
            foreach(var item in this._pages[pageIndex])
            {
                this._visibleData.Add(item);
            }
        }
    }
