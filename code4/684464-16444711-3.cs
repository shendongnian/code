    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        this.MyCombo.DataContext = new MyModel().Items;
        base.OnNavigatedTo(e);
    }
    public class MyModel
    {
        public MyModel()
        {
            foreach (var item in Enumerable.Range(1, 50))
                Items.Add(item);
        }
        ObservableCollection<int> m_Items = new ObservableCollection<int>();
        public ObservableCollection<int> Items { get { return m_Items; } }
    }
