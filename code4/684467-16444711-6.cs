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
                s_Items.Add(item);
        }
        private static ObservableCollection<int> s_Items = new ObservableCollection<int>();
        public ObservableCollection<int> Items { get { return s_Items; } }
    }
