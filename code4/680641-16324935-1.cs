    public partial class LabelledList : Window
    {
        public LabelledList()
        {
            InitializeComponent();
            DataContext = Enumerable.Range(0, 10)
                                    .Select(x => new SomeClass() { DisplayName = "Child" + x.ToString()})
                                    .ToList();
        }
    }
