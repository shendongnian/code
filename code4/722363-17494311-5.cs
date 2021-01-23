    public partial class NestedItemsControls : Window
    {
        public NestedItemsControls()
        {
            InitializeComponent();
            DataContext = new NestedItemsViewModel()
                              {
                                  Level1 = Enumerable.Range(0, 10)
                                                     .Select(l1 => new Level1Item()
                                                        {
                                                            Level2 = Enumerable.Range(0, 10)
                                                                               .Select(l2 => new Level2Item { Value = l1.ToString() + "-" + l2.ToString() })
                                                                               .ToList()
                                                        })
                                                      .ToList()
                              };
        }
    }
