    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        this.MyCombo.DataContext = MyModel.Items;
        base.OnNavigatedTo(e);
    }
    public class MyModel
    {
        public MyModel()
        {
            foreach (var item in Enumerable.Range(1, 50))
                Items.Add(item);
        }
        private static ObservableCollection<int> s_Items = new ObservableCollection<int>();
        public static ObservableCollection<int> Items { get { return s_Items; } }
    }
